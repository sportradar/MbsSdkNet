using System.Net.WebSockets;
using System.Text;
using System.Threading.Channels;
using Sportradar.Mbs.Sdk.Exceptions;
using Sportradar.Mbs.Sdk.Internal.Config;
using Sportradar.Mbs.Sdk.Internal.Connection.Messages;
using Sportradar.Mbs.Sdk.Internal.Connection.Messages.Base;
using Sportradar.Mbs.Sdk.Internal.Utils;

namespace Sportradar.Mbs.Sdk.Internal.Connection;

internal class WebSocketConnection : IDisposable
{
    private const long InitVersion = 0;

    private readonly IWebSocketConnectionConfig _config;

    private readonly Channel<WsInputMessage> _inputBuffer;
    private readonly Channel<WsOutputMessage> _outputBuffer;
    private readonly TokenProvider _tokenProvider;

    private long _connectedVersion = InitVersion;
    private long _reservedVersion = InitVersion;
    private int _connectFailCount = 0;
    private long _connectAttemptTs = TimeUtils.NowInUtcMillis();

    internal WebSocketConnection(
        Channel<WsInputMessage> inputBuffer, Channel<WsOutputMessage> outputBuffer,
        TokenProvider tokenProvider, ImmutableConfig config)
    {
        _tokenProvider = tokenProvider;
        _inputBuffer = inputBuffer;
        _outputBuffer = outputBuffer;
        _config = config;
    }

    public void Dispose()
    {
        var version = Interlocked.Increment(ref _reservedVersion);
        Volatile.Write(ref _connectedVersion, version);
    }

    internal async Task ConnectAsync(CancellationToken cancellationToken)
    {
        try
        {
            await VersionedConnectAsync(InitVersion, cancellationToken).ConfigureAwait(false);
        }
        catch (SdkException)
        {
            throw;
        }
        catch (Exception e)
        {
            throw new WebSocketConnectionException(e);
        }
    }

    private async Task VersionedConnectAsync(long version, CancellationToken cancellationToken)
    {
        var nextVersion = version + 1;
        if (Interlocked.CompareExchange(ref _reservedVersion, nextVersion, version) != version) return;

        try
        {
            int delay = CalculateDelay();
            if (delay > 0)
            {
                await Task.Delay(delay);
            }
            Volatile.Write(ref _connectAttemptTs, TimeUtils.NowInUtcMillis());

            ClientWebSocket? webSocket = null;
            try
            {
                webSocket = await CreateSocketAsync(cancellationToken).ConfigureAwait(false);
                await webSocket.ConnectAsync(_config.WsServer, cancellationToken).ConfigureAwait(false);
                Volatile.Write(ref _connectFailCount, 0);
            }
            catch
            {
                Interlocked.Increment(ref this._connectFailCount);
                ExcSuppress.Dispose(webSocket);
                throw;
            }

            Volatile.Write(ref _connectedVersion, nextVersion);
            StartProcessing(webSocket, nextVersion);
        }
        catch
        {
            Interlocked.CompareExchange(ref _reservedVersion, version, nextVersion);
            throw;
        }
    }

    private void Reconnect(long version)
    {
        _ = Task.Run(() => ReconnectAsync(version));
    }

    private async void ReconnectAsync(long version)
    {
        try
        {
            using var source = new CancellationTokenSource(_config.WsReconnectTimeout);
            await VersionedConnectAsync(version, source.Token).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            LogException(e);
            Reconnect(version);
        }
    }

    private int CalculateDelay()
    {
        int count = Math.Min(8, Volatile.Read(ref this._connectFailCount));
        if (count == 0)
        {
            return 0;
        }
        long maxSleep = 125L * ((long)Math.Pow(2, count));
        long diffTs = TimeUtils.NowInUtcMillis() - Volatile.Read(ref this._connectAttemptTs);
        return (int)(maxSleep - diffTs);
    }

    private async void StartProcessing(ClientWebSocket webSocket, long version)
    {
        try
        {
            _ = Task.Delay(_config.WsRefreshConnectionTimeout).ContinueWith(_ => ReconnectAsync(version));
            await Task.WhenAll(
                    ResponseReceiveLoopAsync(webSocket, version),
                    RequestSendLoopAsync(webSocket, version))
                .ConfigureAwait(false);
        }
        catch
        {
            ReconnectAsync(version);
        }
        finally
        {
            ExcSuppress.Dispose(webSocket);
        }
    }

    private async Task ResponseReceiveLoopAsync(ClientWebSocket webSocket, long version)
    {
        try
        {
            while (version == Volatile.Read(ref _connectedVersion))
            {
                if (webSocket.State != WebSocketState.Open) break;

                await ResponseReceiveAsync(webSocket).ConfigureAwait(false);
            }

            using var source = new CancellationTokenSource(_config.WsConsumerGraceTimeout);
            while (!source.Token.IsCancellationRequested)
            {
                if (webSocket.State != WebSocketState.Open) break;

                await ResponseReceiveAsync(webSocket).ConfigureAwait(false);
            }
        }
        catch (Exception e)
        {
            LogException(e);
        }
        finally
        {
            ReconnectAsync(version);
        }
    }

    private async Task RequestSendLoopAsync(ClientWebSocket webSocket, long version)
    {
        try
        {
            while (!_inputBuffer.Reader.Completion.IsCompleted && version == Volatile.Read(ref _connectedVersion))
            {
                if (webSocket.State != WebSocketState.Open) break;

                var msg = await RequestMessageReadAsync().ConfigureAwait(false);
                if (msg == null) continue;
                if (msg is not SendWsInputMessage sendMsg || sendMsg.IsSuppressed)
                {
                    _outputBuffer.Writer.TryWrite(new NotProcessedWsOutputMessage(msg));
                    continue;
                }

                await SendMessageAsync(webSocket, sendMsg).ConfigureAwait(false);
                _outputBuffer.Writer.TryWrite(new SentWsOutputMessage(msg));
            }
        }
        catch (Exception e)
        {
            LogException(e);
        }
        finally
        {
            ReconnectAsync(version);
        }
    }

    private async Task<WsInputMessage?> RequestMessageReadAsync()
    {
        try
        {
            using var source = new CancellationTokenSource(_config.WsFetchMessageTimeout);
            return await _inputBuffer.Reader.ReadAsync(source.Token).ConfigureAwait(false);
        }
        catch
        {
            return null;
        }
    }

    private async Task SendMessageAsync(ClientWebSocket webSocket, SendWsInputMessage message)
    {
        var chunks = message.Content;
        for (var i = 0; i < chunks.Count; i++)
        {
            using var source = new CancellationTokenSource(_config.WsSendMessageTimeout);
            await webSocket.SendAsync(
                    new ArraySegment<byte>(chunks[i]), WebSocketMessageType.Text,
                    i + 1 == chunks.Count, source.Token)
                .ConfigureAwait(false);
        }
    }

    private async Task ResponseReceiveAsync(ClientWebSocket webSocket)
    {
        var msg = await ResponseMessageReceiveAsync(webSocket).ConfigureAwait(false);
        if (string.IsNullOrEmpty(msg)) return;
        await _outputBuffer.Writer.WriteAsync(new ReceivedContentWsOutputMessage(msg)).ConfigureAwait(false);
    }

    private async Task<string> ResponseMessageReceiveAsync(ClientWebSocket webSocket)
    {
        var buffer = new StringBuilder();
        while (true)
        {
            var (result, data) = await ResponseChunkReceiveAsync(webSocket).ConfigureAwait(false);
            if (result.Count > 0) buffer.Append(Encoding.UTF8.GetString(data, 0, result.Count));
            if (result.EndOfMessage) break;
        }

        return buffer.ToString();
    }

    private async Task<(WebSocketReceiveResult, byte[])> ResponseChunkReceiveAsync(ClientWebSocket webSocket)
    {
        using var source = new CancellationTokenSource(_config.WsReceiveMessageTimeout);
        var buffer = new ArraySegment<byte>(new byte[16384]);
        var result = await webSocket.ReceiveAsync(buffer, source.Token).ConfigureAwait(false);
        if (result.MessageType == WebSocketMessageType.Close)
            await CloseSocketAsync(webSocket, result);

        return (result, buffer.Array ?? Array.Empty<byte>());
    }

    private async Task CloseSocketAsync(ClientWebSocket webSocket, WebSocketReceiveResult result)
    {
        using var source = new CancellationTokenSource(_config.WsSendMessageTimeout);
        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, source.Token)
            .ConfigureAwait(false);
        throw new WebSocketConnectionException("Socket closed: " + result.CloseStatusDescription);
    }

    private void LogException(Exception exc)
    {
        ExcSuppress.Invoke(() =>
        {
            var sdkException = exc as SdkException ?? new WebSocketConnectionException(exc);
            _outputBuffer.Writer.TryWrite(new ExcWsOutputMessage(null, sdkException));
        });
    }

    private async Task<ClientWebSocket> CreateSocketAsync(CancellationToken cancellationToken)
    {
        var token = await _tokenProvider.GetAuthTokenAsync(cancellationToken).ConfigureAwait(false);
        ClientWebSocket socket = new();
        socket.Options.SetRequestHeader("Authorization", $"Bearer {token}");
        return socket;
    }
}

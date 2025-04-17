using Sportradar.Mbs.Sdk.Entities.Response;
using Sportradar.Mbs.Sdk.Exceptions;
using Sportradar.Mbs.Sdk.Internal.Connection.Messages;
using Sportradar.Mbs.Sdk.Internal.Connection.Messages.Base;
using Sportradar.Mbs.Sdk.Internal.Utils;

namespace Sportradar.Mbs.Sdk.Internal.Protocol;

internal partial class ProtocolProvider
{
    public event UnhandledExceptionEventHandler? UnhandledException;

    private void StartDispatchers()
    {
        for (var i = 0; i < _config.ProtocolNumberOfDispatchers; i++)
            StartDispatcher();
    }

    private void StartDispatcher()
    {
        if (_connected)
            _ = Task.Run(Dispatcher);
    }

    private async void Dispatcher()
    {
        try
        {
            while (_connected)
            {
                var msg = await ReadWsOutputMessageAsync().ConfigureAwait(false);
                if (msg == null) continue;
                HandleWsOutputMessage(msg);
            }
        }
        catch
        {
            StartDispatcher();
        }
    }

    private async Task<WsOutputMessage?> ReadWsOutputMessageAsync()
    {
        try
        {
            using var source = new CancellationTokenSource(_config.ProtocolDequeueTimeout);
            return await _wsOutputBuffer.Reader.ReadAsync(source.Token).ConfigureAwait(false);
        }
        catch
        {
            return null;
        }
    }

    private void HandleWsOutputMessage(WsOutputMessage message)
    {
        switch (message)
        {
            case ReceivedContentWsOutputMessage c:
                HandleReceivedContentWsOutputMessage(c);
                break;
            case ExcWsOutputMessage e:
                HandleExcWsOutputMessage(e);
                break;
            case NotProcessedWsOutputMessage np:
                HandleNotProcessedWsOutputMessage(np);
                break;
        }
    }

    private void HandleExcWsOutputMessage(ExcWsOutputMessage message)
    {
        try
        {
            if (!ResponseReceived(message.CorrelationId, message.Exception)) HandleException(message.Exception);
        }
        catch (Exception e)
        {
            HandleException(e);
        }
    }

    private void HandleNotProcessedWsOutputMessage(NotProcessedWsOutputMessage message)
    {
        try
        {
            var invalidRequestException = new ProtocolInvalidResponseException("Invalid request");
            if (ResponseReceived(message.CorrelationId, invalidRequestException)) return;

            HandleException(invalidRequestException);
        }
        catch (Exception e)
        {
            HandleException(e);
        }
    }

    private void HandleReceivedContentWsOutputMessage(ReceivedContentWsOutputMessage message)
    {
        try
        {
            var response = message.Content.DeserializeResponse();
            if (response.CorrelationId == null)
            {
                HandleException(new ProtocolInvalidResponseException("Missing CorrelationId: " + message.Content));
                return;
            }

            if (ResponseReceived(response.CorrelationId, response)) return;

            if (response.Content is ErrorResponse error)
            {
                var sdkException = new ServerErrorResponseException(
                    error.ErrorCode, error.ErrorMessage ?? "Unknown error");
                if (ResponseReceived(response.CorrelationId, sdkException)) return;
            }

            var invalidResponseException =
                new ProtocolInvalidResponseException("Invalid response: " + message.Content);

            if (ResponseReceived(response.CorrelationId, invalidResponseException)) return;

            HandleException(invalidResponseException);
        }
        catch (Exception e)
        {
            HandleException(e);
        }
    }

    private void HandleException(Exception exception)
    {
        UnhandledException?.Invoke(this, new UnhandledExceptionEventArgs(exception, false));
    }
}

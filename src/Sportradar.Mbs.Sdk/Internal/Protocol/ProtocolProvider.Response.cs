using System.Collections.Concurrent;
using System.Text;
using Sportradar.Mbs.Sdk.Entities.Internal;
using Sportradar.Mbs.Sdk.Entities.Response;
using Sportradar.Mbs.Sdk.Exceptions;
using Sportradar.Mbs.Sdk.Internal.Connection.Messages;
using Sportradar.Mbs.Sdk.Internal.Utils;

namespace Sportradar.Mbs.Sdk.Internal.Protocol;

internal partial class ProtocolProvider
{
    private static readonly int ChunkSize = 32_000;
    private static readonly int MessageSize = 4 * ChunkSize;

    private readonly ConcurrentDictionary<string, Awaiter> _correlationIdAwaiter = new();
    private int _approxRequestCount;

    private string ReserveCorrelationId<T>()
        where T : ContentResponseBase
    {
        if (_approxRequestCount > _config.ProtocolMaxSendBufferSize)
            throw new ProtocolSendBufferFullException();

        var awaiter = new Awaiter(typeof(T));
        while (true)
        {
            var correlationId = Extensions.RandomString();
            if (_correlationIdAwaiter.TryAdd(correlationId, awaiter))
            {
                Interlocked.Increment(ref _approxRequestCount);
                return correlationId;
            }
        }
    }

    private async Task<T> EnqueueRequestAndAwaitResponseAsync<T>(string correlationId, Request request)
        where T : ContentResponseBase
    {
        var awaiter = _correlationIdAwaiter[correlationId];
        var message = new SendWsInputMessage(correlationId, CreateContent(request));
        while (awaiter.PrepareNewTry(_config.ProtocolRetryCount, out var tryCount))
            try
            {
                await EnqueueMessageAsync(message);
                await AwaitResponseAsync(awaiter, tryCount);
            }
            catch (SdkException e)
            {
                awaiter.CompleteWithException(e);
            }

        message.SuppressSend();
        return awaiter.GetResult<T>();
    }

    private void ReleaseCorrelationId(string correlationId)
    {
        if (_correlationIdAwaiter.TryRemove(correlationId, out _)) Interlocked.Decrement(ref _approxRequestCount);
    }

    private async Task EnqueueMessageAsync(SendWsInputMessage message)
    {
        try
        {
            using var source = new CancellationTokenSource(_config.ProtocolEnqueueTimeout);
            await _wsInputBuffer.Writer.WriteAsync(message, source.Token).ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        {
            throw new ProtocolSendBufferFullException();
        }
    }

    private async Task AwaitResponseAsync(Awaiter awaiter, int tryCount)
    {
        _ = Task.Delay(_config.ProtocolReceiveResponseTimeout).ContinueWith(_ => awaiter.Timeout(tryCount));
        await awaiter.Task.ConfigureAwait(false);
    }

    private bool ResponseReceived(string correlationId, Response response)
    {
        if (response.Content != null
            && _correlationIdAwaiter.TryGetValue(correlationId, out var awaiter)
            && awaiter.CheckResponseType(response.Content))
        {
            awaiter.CompleteSuccess(response.Content);
            return true;
        }

        return false;
    }

    private bool ResponseReceived(string correlationId, SdkException sdkException)
    {
        if (_correlationIdAwaiter.TryGetValue(correlationId, out var awaiter))
        {
            awaiter.CompleteWithException(sdkException);
            return true;
        }

        return false;
    }

    private static List<byte[]> CreateContent(Request request)
    {
        var bytes = Encoding.UTF8.GetBytes(request.SerializeRequest());
        if (bytes.Length > MessageSize) throw new ProtocolMessageTooBigException();

        var result = new List<byte[]>();
        var offset = 0;
        while (offset < bytes.Length)
        {
            var chunkSize = Math.Min(bytes.Length - offset, ChunkSize);
            var chunk = new byte[chunkSize];
            Array.Copy(bytes, offset, chunk, 0, chunkSize);
            result.Add(chunk);
            offset += chunkSize;
        }

        return result;
    }

    private class Awaiter
    {
        private readonly Type _contentResponseType;
        private readonly object _lock = new();
        private int _retryCount = -1;
        private TaskCompletionSource<ContentResponseBase>? _source;

        public Awaiter(Type type)
        {
            _contentResponseType = type;
        }

        public Task<ContentResponseBase> Task
        {
            get
            {
                lock (_lock) return _source.NotNull(nameof(_source)).Task;
            }
        }

        public void Timeout(int tryCount)
        {
            lock (_lock)
            {
                if (_retryCount != tryCount) return;

                _source.NotNull(nameof(_source)).TrySetException(new ProtocolTimeoutException());
            }
        }

        public void CompleteWithException(SdkException sdkException)
        {
            lock (_lock)
            {
                _source.NotNull(nameof(_source)).TrySetException(sdkException);
            }
        }

        public void CompleteSuccess(ContentResponseBase contentResponseBase)
        {
            lock (_lock)
            {
                _source.NotNull(nameof(_source)).TrySetResult(contentResponseBase);
            }
        }

        public bool CheckResponseType(ContentResponseBase contentResponseBase)
        {
            return _contentResponseType.IsInstanceOfType(contentResponseBase);
        }

        public T GetResult<T>() where T : ContentResponseBase
        {
            return (T)Task.Result;
        }

        public bool PrepareNewTry(int maxTryCount, out int tryCount)
        {
            lock (_lock)
            {
                tryCount = _retryCount + 1;
                if (tryCount > maxTryCount) return false;
                _retryCount = tryCount;

                var task = _source?.Task;
                if (task != null && task.IsCompleted && !task.IsFaulted) return false;

                _source = new();
                return true;
            }
        }
    }
}

using Sportradar.Mbs.Sdk.Entities.Internal;
using Sportradar.Mbs.Sdk.Entities.Request;
using Sportradar.Mbs.Sdk.Entities.Response;
using Sportradar.Mbs.Sdk.Exceptions;
using Sportradar.Mbs.Sdk.Internal.Utils;

namespace Sportradar.Mbs.Sdk.Internal.Protocol;

internal partial class ProtocolEngine
{
    internal async Task<T> ProcessRequestAsync<T>(long operatorId, string? operation, ContentRequestBase content)
        where T : ContentResponseBase
    {
        CheckConnected();
        var correlationId = ReserveCorrelationId<T>();
        try
        {
            var request = new Request
            {
                Content = content,
                Operation = operation,
                CorrelationId = correlationId,
                Version = "3.0",
                OperatorId = operatorId,
                TimestampUtc = TimeUtils.NowInUtcMillis()
            };
            return await EnqueueRequestAndAwaitResponseAsync<T>(correlationId, request).ConfigureAwait(false);
        }
        catch (SdkException)
        {
            throw;
        }
        catch (Exception e)
        {
            throw new ProtocolSendFailedException(e);
        }
        finally
        {
            ReleaseCorrelationId(correlationId);
        }
    }
}
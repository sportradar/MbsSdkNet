using Sportradar.Mbs.Sdk.Entities.Request;
using Sportradar.Mbs.Sdk.Entities.Response;
using Sportradar.Mbs.Sdk.Protocol;

namespace Sportradar.Mbs.Sdk.Internal.Protocol;

internal class GamingProtocol : IGamingProtocol
{
    private readonly long _operatorId;
    private readonly ProtocolEngine _engine;

    internal GamingProtocol(long operatorId, ProtocolEngine engine)
    {
        _operatorId = operatorId;
        _engine = engine;
    }

    /// <summary>
    /// Sends a casino sessions inform request.
    /// </summary>
    /// <param name="request">The casino sessions request to send.</param>
    /// <returns>The response indicating the status of the casino sessions notification.</returns>
    public async Task<CasinoSessionsResponse> SendCasinoSessionInformAsync(CasinoSessionsRequest request)
    {
        return await _engine.ProcessRequestAsync<CasinoSessionsResponse>(
            _operatorId, "casino-sessions-inform", request).ConfigureAwait(false);
    }
}
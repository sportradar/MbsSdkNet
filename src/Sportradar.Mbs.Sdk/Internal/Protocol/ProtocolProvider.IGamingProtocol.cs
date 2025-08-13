using Sportradar.Mbs.Sdk.Entities.Request;
using Sportradar.Mbs.Sdk.Entities.Response;
using Sportradar.Mbs.Sdk.Protocol;

namespace Sportradar.Mbs.Sdk.Internal.Protocol;

internal partial class ProtocolProvider : IGamingProtocol
{
  internal IGamingProtocol GamingProtocol => this;

  /// <summary>
  /// Sends a casino sessions inform request.
  /// </summary>
  /// <param name="request">The casino sessions request to send.</param>
  /// <returns>The response indicating the status of the casino sessions notification.</returns>
  public async Task<CasinoSessionsResponse> SendCasinoSessionInformAsync(CasinoSessionsRequest request)
  {
    return await ProcessRequestAsync<CasinoSessionsResponse>(
        "casino-sessions-inform", request).ConfigureAwait(false);
  }
}

using Sportradar.Mbs.Sdk.Entities.Request;
using Sportradar.Mbs.Sdk.Entities.Response;

namespace Sportradar.Mbs.Sdk.Protocol;

/// <summary>
/// Defines the contract for handling balance-related protocol operations.
/// </summary>
public interface IGamingProtocol
{
    /// <summary>
    /// Sends a casino sessions inform request.
    /// </summary>
    /// <param name="request">The casino sessions request to send.</param>
    /// <returns>The response indicating the status of the casino sessions notification.</returns>
    Task<CasinoSessionsResponse> SendCasinoSessionInformAsync(CasinoSessionsRequest request);
}

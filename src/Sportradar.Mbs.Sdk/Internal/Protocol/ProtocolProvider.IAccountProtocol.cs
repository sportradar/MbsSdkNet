using Sportradar.Mbs.Sdk.Entities.Request;
using Sportradar.Mbs.Sdk.Entities.Response;
using Sportradar.Mbs.Sdk.Protocol;

namespace Sportradar.Mbs.Sdk.Internal.Protocol;

internal partial class ProtocolProvider : IAccountProtocol
{
    internal IAccountProtocol AccountProtocol => this;

    /// <summary>
    /// Sends an account status inform request.
    /// </summary>
    /// <param name="request">The account request to send.</param>
    /// <returns>The response containing account status details.</returns>
    /// <exception cref="SdkException">Thrown when operation has failed.</exception>
    public async Task<AccountStatusInformResponse> SendAccountStatusInformAsync(
       AccountStatusInformRequest request)
    {
        return await ProcessRequestAsync<AccountStatusInformResponse>(
            "account-status-inform", request).ConfigureAwait(false);
    }

    /// <summary>
    /// Sends a account limit inform request.
    /// </summary>
    /// <param name="request">The account limit request to send.</param>
    /// <returns>The response indicating the status of the account limit update.</returns>
    public async Task<AccountLimitInformResponse> SendAccountLimitInformAsync(
       AccountLimitInformRequest request)
    {
        return await ProcessRequestAsync<AccountLimitInformResponse>(
            "account-limit-inform", request).ConfigureAwait(false);
    }

    /// <summary>
    /// Sends a limit reached inform request.
    /// </summary>
    /// <param name="request">The limit reached request to send.</param>
    /// <returns>The response indicating the status of the limit reached notification.</returns>
    public async Task<AccountLimitReachedInformResponse> SendAccountLimitReachedInformAsync(
       AccountLimitReachedInformRequest request)
    {
        return await ProcessRequestAsync<AccountLimitReachedInformResponse>(
            "account-limit-reached-inform", request).ConfigureAwait(false);
    }

    /// <summary>
    /// Sends a account intervention inform request.
    /// </summary>
    /// <param name="request">The account intervention request to send.</param>
    /// <returns>The response indicating the status of the intervention notification.</returns>
    public async Task<AccountInterventionInformResponse> SendAccountInterventionInformAsync(
       AccountInterventionInformRequest request)
    {
        return await ProcessRequestAsync<AccountInterventionInformResponse>(
            "account-intervention-inform", request).ConfigureAwait(false);
    }
}

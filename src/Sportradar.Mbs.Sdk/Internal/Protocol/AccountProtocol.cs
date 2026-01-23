using Sportradar.Mbs.Sdk.Entities.Request;
using Sportradar.Mbs.Sdk.Entities.Response;
using Sportradar.Mbs.Sdk.Protocol;

namespace Sportradar.Mbs.Sdk.Internal.Protocol;

internal class AccountProtocol : IAccountProtocol
{
    private readonly long _operatorId;
    private readonly ProtocolEngine _engine;

    internal AccountProtocol(long operatorId, ProtocolEngine engine)
    {
        _operatorId = operatorId;
        _engine = engine;
    }

    /// <summary>
    /// Sends an account status inform request.
    /// </summary>
    /// <param name="request">The account request to send.</param>
    /// <returns>The response containing account status details.</returns>
    /// <exception cref="SdkException">Thrown when operation has failed.</exception>
    public async Task<AccountStatusInformResponse> SendAccountStatusInformAsync(
        AccountStatusInformRequest request)
    {
        return await _engine.ProcessRequestAsync<AccountStatusInformResponse>(
            _operatorId, "account-status-inform", request).ConfigureAwait(false);
    }

    /// <summary>
    /// Sends a account limit inform request.
    /// </summary>
    /// <param name="request">The account limit request to send.</param>
    /// <returns>The response indicating the status of the account limit update.</returns>
    public async Task<AccountLimitInformResponse> SendAccountLimitInformAsync(
        AccountLimitInformRequest request)
    {
        return await _engine.ProcessRequestAsync<AccountLimitInformResponse>(
            _operatorId, "account-limit-inform", request).ConfigureAwait(false);
    }

    /// <summary>
    /// Sends a limit reached inform request.
    /// </summary>
    /// <param name="request">The limit reached request to send.</param>
    /// <returns>The response indicating the status of the limit reached notification.</returns>
    public async Task<AccountLimitReachedInformResponse> SendAccountLimitReachedInformAsync(
        AccountLimitReachedInformRequest request)
    {
        return await _engine.ProcessRequestAsync<AccountLimitReachedInformResponse>(
            _operatorId, "account-limit-reached-inform", request).ConfigureAwait(false);
    }

    /// <summary>
    /// Sends a account intervention inform request.
    /// </summary>
    /// <param name="request">The account intervention request to send.</param>
    /// <returns>The response indicating the status of the intervention notification.</returns>
    public async Task<AccountInterventionInformResponse> SendAccountInterventionInformAsync(
        AccountInterventionInformRequest request)
    {
        return await _engine.ProcessRequestAsync<AccountInterventionInformResponse>(
            _operatorId, "account-intervention-inform", request).ConfigureAwait(false);
    }
}
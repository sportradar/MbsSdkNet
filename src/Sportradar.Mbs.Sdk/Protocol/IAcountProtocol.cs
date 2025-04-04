using Sportradar.Mbs.Sdk.Entities.Request;
using Sportradar.Mbs.Sdk.Entities.Response;

namespace Sportradar.Mbs.Sdk.Protocol;

/// <summary>
/// Defines the contract for handling account-related protocol operations.
/// </summary>
public interface IAccountProtocol
{
    /// <summary>
    /// Sends an account status inform request.
    /// </summary>
    /// <param name="request">The account request to send.</param>
    /// <returns>The response containing account status details.</returns>
    /// <exception cref="SdkException">Thrown when operation has failed.</exception>
    Task<AccountStatusInformResponse> SendAccountStatusInformAsync(AccountStatusInformRequest request);

    /// <summary>
    /// Sends a account limit inform request.
    /// </summary>
    /// <param name="request">The account limit request to send.</param>
    /// <returns>The response indicating the status of the account limit update.</returns>
    Task<AccountLimitInformResponse> SendAccountLimitInformAsync(AccountLimitInformRequest request);

    /// <summary>
    /// Sends a limit reached inform request.
    /// </summary>
    /// <param name="request">The limit reached request to send.</param>
    /// <returns>The response indicating the status of the limit reached notification.</returns>
    Task<AccountLimitReachedInformResponse> SendAccountLimitReachedInformAsync(AccountLimitReachedInformRequest request);

    /// <summary>
    /// Sends a account intervention inform request.
    /// </summary>
    /// <param name="request">The account intervention request to send.</param>
    /// <returns>The response indicating the status of the intervention notification.</returns>
    Task<AccountInterventionInformResponse> SendAccountInterventionInformAsync(AccountInterventionInformRequest request);
}

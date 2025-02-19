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
    /// Sends a financial limit inform request.
    /// </summary>
    /// <param name="request">The financial limit request to send.</param>
    /// <returns>The response indicating the status of the financial limit update.</returns>
    Task<FinancialLimitInformResponse> SendFinancialLimitInformAsync(FinancialLimitInformRequest request);

    /// <summary>
    /// Sends a limit reached inform request.
    /// </summary>
    /// <param name="request">The limit reached request to send.</param>
    /// <returns>The response indicating the status of the limit reached notification.</returns>
    Task<LimitReachedInformResponse> SendLimitReachedInformAsync(LimitReachedInformRequest request);

    /// <summary>
    /// Sends a session limit inform request.
    /// </summary>
    /// <param name="request">The session limit request to send.</param>
    /// <returns>The response indicating the status of the session limit notification.</returns>
    Task<SessionLimitInformResponse> SendSessionLimitInformAsync(SessionLimitInformRequest request);
}

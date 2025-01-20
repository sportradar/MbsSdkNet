using Sportradar.Mbs.Sdk.Entities.Request;
using Sportradar.Mbs.Sdk.Entities.Response;

namespace Sportradar.Mbs.Sdk.Protocol;

/// <summary>
/// Defines the methods for interacting with the account protocol.
/// </summary>
public interface IAccountProtocol
{
    /// <summary>
    /// Sends an account status inform request asynchronously.
    /// </summary>
    /// <param name="request">The account status inform request to send.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the account status inform response.</returns>
    /// <exception cref="SdkException">Thrown when operation has failed.</exception>
    Task<AccountStatusInformResponse> SendAccountStatusInformAsync(AccountStatusInformRequest request);

    /// <summary>
    /// Sends a financial limit inform request asynchronously.
    /// </summary>
    /// <param name="request">The financial limit inform request to send.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the financial limit inform response.</returns>
    /// <exception cref="SdkException">Thrown when operation has failed.</exception>
    Task<FinancialLimitInformResponse> SendFinancialLimitInformAsync(FinancialLimitInformRequest request);

    /// <summary>
    /// Sends a session limit inform request asynchronously.
    /// </summary>
    /// <param name="request">The session limit inform request to send.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the session limit inform response.</returns>
    /// <exception cref="SdkException">Thrown when operation has failed.</exception>
    Task<SessionLimitInformResponse> SendSessionLimitInformAsync(SessionLimitInformRequest request);

    /// <summary>
    /// Sends a limit reached inform request asynchronously.
    /// </summary>
    /// <param name="request">The limit reached inform request to send.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the limit reached inform response.</returns>
    /// <exception cref="SdkException">Thrown when operation has failed.</exception>
    Task<LimitReachedInformResponse> SendLimitReachedInformAsync(LimitReachedInformRequest request);

}
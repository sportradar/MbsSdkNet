using Sportradar.Mbs.Sdk.Entities.Request;
using Sportradar.Mbs.Sdk.Entities.Response;

namespace Sportradar.Mbs.Sdk.Protocol;

/// <summary>
/// Defines the methods for interacting with the balance protocol.
/// </summary>
public interface IBalanceProtocol
{
    /// <summary>
    /// Sends a deposit inform request asynchronously.
    /// </summary>
    /// <param name="request">The deposit inform request to send.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the deposit inform response.</returns>
    /// <exception cref="SdkException">Thrown when operation has failed.</exception>
    Task<DepositInformResponse> SendDepositInformAsync(DepositInformRequest request);

    /// <summary>
    /// Sends a withdrawal inform request asynchronously.
    /// </summary>
    /// <param name="request">The withdrawal inform request to send.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the withdrawal inform response.</returns>
    /// <exception cref="SdkException">Thrown when operation has failed.</exception>
    Task<WithdrawalInformResponse> SendWithdrawalInformAsync(WithdrawalInformRequest request);
}
using Sportradar.Mbs.Sdk.Entities.Request;
using Sportradar.Mbs.Sdk.Entities.Response;

namespace Sportradar.Mbs.Sdk.Protocol;

/// <summary>
/// Defines the contract for handling balance-related protocol operations.
/// </summary>
public interface IBalanceProtocol
{
    /// <summary>
    /// Sends a deposit inform request.
    /// </summary>
    /// <param name="request">The deposit request to send.</param>
    /// <returns>The response indicating the status of the deposit notification.</returns>
    Task<DepositInformResponse> SendDepositInformAsync(DepositInformRequest request);

    /// <summary>
    /// Sends a withdrawal inform request.
    /// </summary>
    /// <param name="request">The withdrawal request to send.</param>
    /// <returns>The response indicating the status of the withdrawal notification.</returns>
    Task<WithdrawalInformResponse> SendWithdrawalInformAsync(WithdrawalInformRequest request);
}

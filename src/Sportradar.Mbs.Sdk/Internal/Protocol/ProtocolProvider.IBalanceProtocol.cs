using Sportradar.Mbs.Sdk.Entities.Request;
using Sportradar.Mbs.Sdk.Entities.Response;
using Sportradar.Mbs.Sdk.Protocol;

namespace Sportradar.Mbs.Sdk.Internal.Protocol;

internal partial class ProtocolProvider : IBalanceProtocol
{
    internal IBalanceProtocol BalanceProtocol => this;

    /// <summary>
    /// Sends a deposit inform request.
    /// </summary>
    /// <param name="request">The deposit request to send.</param>
    /// <returns>The response indicating the status of the deposit notification.</returns>
    public async Task<DepositInformResponse> SendDepositInformAsync(DepositInformRequest request)
    {
        return await ProcessRequestAsync<DepositInformResponse>(
            "balance-deposit-inform", request).ConfigureAwait(false);
    }

    /// <summary>
    /// Sends a withdrawal inform request.
    /// </summary>
    /// <param name="request">The withdrawal request to send.</param>
    /// <returns>The response indicating the status of the withdrawal notification.</returns>
    public async Task<WithdrawalInformResponse> SendWithdrawalInformAsync(WithdrawalInformRequest request)
    {
        return await ProcessRequestAsync<WithdrawalInformResponse>(
            "balance-withdrawal-inform", request).ConfigureAwait(false);
    }
}

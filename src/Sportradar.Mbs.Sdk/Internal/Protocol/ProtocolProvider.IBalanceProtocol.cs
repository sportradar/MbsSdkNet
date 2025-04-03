using Sportradar.Mbs.Sdk.Entities.Request;
using Sportradar.Mbs.Sdk.Entities.Response;
using Sportradar.Mbs.Sdk.Protocol;

namespace Sportradar.Mbs.Sdk.Internal.Protocol;

internal partial class ProtocolProvider : IBalanceProtocol
{
    internal IBalanceProtocol BalanceProtocol => this;

    public async Task<DepositInformResponse> SendDepositInformAsync(DepositInformRequest request)
    {
        return await ProcessRequestAsync<DepositInformResponse>("balance-deposit-inform", request).ConfigureAwait(false);
    }

    public async Task<WithdrawalInformResponse> SendWithdrawalInformAsync(WithdrawalInformRequest request)
    {
        return await ProcessRequestAsync<WithdrawalInformResponse>("balance-withdrawal-inform", request).ConfigureAwait(false);
    }
}
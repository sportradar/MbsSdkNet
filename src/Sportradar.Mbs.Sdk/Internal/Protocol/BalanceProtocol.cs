using Sportradar.Mbs.Sdk.Entities.Request;
using Sportradar.Mbs.Sdk.Entities.Response;
using Sportradar.Mbs.Sdk.Protocol;

namespace Sportradar.Mbs.Sdk.Internal.Protocol;

internal class BalanceProtocol : IBalanceProtocol
{
    private readonly long _operatorId;
    private readonly ProtocolEngine _engine;

    internal BalanceProtocol(long operatorId, ProtocolEngine engine)
    {
        _operatorId = operatorId;
        _engine = engine;
    }

    /// <summary>
    /// Sends a deposit inform request.
    /// </summary>
    /// <param name="request">The deposit request to send.</param>
    /// <returns>The response indicating the status of the deposit notification.</returns>
    public async Task<DepositInformResponse> SendDepositInformAsync(DepositInformRequest request)
    {
        return await _engine.ProcessRequestAsync<DepositInformResponse>(
            _operatorId, "balance-deposit-inform", request).ConfigureAwait(false);
    }

    /// <summary>
    /// Sends a withdrawal inform request.
    /// </summary>
    /// <param name="request">The withdrawal request to send.</param>
    /// <returns>The response indicating the status of the withdrawal notification.</returns>
    public async Task<WithdrawalInformResponse> SendWithdrawalInformAsync(WithdrawalInformRequest request)
    {
        return await _engine.ProcessRequestAsync<WithdrawalInformResponse>(
            _operatorId, "balance-withdrawal-inform", request).ConfigureAwait(false);
    }
}
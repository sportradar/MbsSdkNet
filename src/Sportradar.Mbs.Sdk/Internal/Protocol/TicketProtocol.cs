using Sportradar.Mbs.Sdk.Entities.Request;
using Sportradar.Mbs.Sdk.Entities.Response;
using Sportradar.Mbs.Sdk.Protocol;

namespace Sportradar.Mbs.Sdk.Internal.Protocol;

internal class TicketProtocol : ITicketProtocol
{
    private readonly long _operatorId;
    private readonly ProtocolEngine _engine;

    internal TicketProtocol(long operatorId, ProtocolEngine engine)
    {
        _operatorId = operatorId;
        _engine = engine;
    }

    public async Task<TicketResponse> SendTicketAsync(TicketRequest request)
    {
        return await _engine.ProcessRequestAsync<TicketResponse>(
            _operatorId, "ticket-placement", request).ConfigureAwait(false);
    }

    public async Task<TicketInformResponse> SendTicketInformAsync(TicketInformRequest request)
    {
        return await _engine.ProcessRequestAsync<TicketInformResponse>(
            _operatorId, "ticket-placement-inform", request).ConfigureAwait(false);
    }

    public async Task<TicketAckResponse> SendTicketAckAsync(TicketAckRequest request)
    {
        return await _engine.ProcessRequestAsync<TicketAckResponse>(
            _operatorId, "ticket-placement-ack", request).ConfigureAwait(false);
    }

    public async Task<CancelResponse> SendCancelAsync(CancelRequest request)
    {
        return await _engine.ProcessRequestAsync<CancelResponse>(
            _operatorId, "ticket-cancel", request).ConfigureAwait(false);
    }

    public async Task<CancelAckResponse> SendCancelAckAsync(CancelAckRequest request)
    {
        return await _engine.ProcessRequestAsync<CancelAckResponse>(
            _operatorId, "ticket-cancel-ack", request).ConfigureAwait(false);
    }

    public async Task<CashoutResponse> SendCashoutAsync(CashoutRequest request)
    {
        return await _engine.ProcessRequestAsync<CashoutResponse>(
            _operatorId, "ticket-cashout", request).ConfigureAwait(false);
    }

    public async Task<CashoutInformResponse> SendCashoutInformAsync(CashoutInformRequest request)
    {
        return await _engine.ProcessRequestAsync<CashoutInformResponse>(
            _operatorId, "cashout-inform", request).ConfigureAwait(false);
    }

    public async Task<CashoutAckResponse> SendCashoutAckAsync(CashoutAckRequest request)
    {
        return await _engine.ProcessRequestAsync<CashoutAckResponse>(
            _operatorId, "ticket-cashout-ack", request).ConfigureAwait(false);
    }

    public async Task<CashoutBuildResponse> SendCashoutBuildAsync(CashoutBuildRequest request)
    {
        return await _engine.ProcessRequestAsync<CashoutBuildResponse>(
            _operatorId, "cashout-build", request).ConfigureAwait(false);
    }

    public async Task<CashoutPlacementResponse> SendCashoutPlacementAsync(CashoutPlacementRequest request)
    {
        return await _engine.ProcessRequestAsync<CashoutPlacementResponse>(
            _operatorId, "cashout-placement", request).ConfigureAwait(false);
    }

    public async Task<ExtSettlementResponse> SendExtSettlementAsync(ExtSettlementRequest request)
    {
        return await _engine.ProcessRequestAsync<ExtSettlementResponse>(
            _operatorId, "ticket-ext-settlement", request).ConfigureAwait(false);
    }

    public async Task<ExtSettlementAckResponse> SendExtSettlementAckAsync(ExtSettlementAckRequest request)
    {
        return await _engine.ProcessRequestAsync<ExtSettlementAckResponse>(
            _operatorId, "ticket-ext-settlement-ack", request).ConfigureAwait(false);
    }

    public async Task<MaxStakeResponse> SendMaxStakeAsync(MaxStakeRequest request)
    {
        return await _engine.ProcessRequestAsync<MaxStakeResponse>(
            _operatorId, "max-stake", request).ConfigureAwait(false);
    }

    public async Task<PayoutModifierSettlementResponse> SendPayoutModifierSettlementAsync(
        PayoutModifierSettlementRequest request)
    {
        return await _engine.ProcessRequestAsync<PayoutModifierSettlementResponse>(
            _operatorId, "payout-modifier-settlement", request).ConfigureAwait(false);
    }
}
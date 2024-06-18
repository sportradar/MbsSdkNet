using Sportradar.Mbs.Sdk.Entities.Request;
using Sportradar.Mbs.Sdk.Entities.Response;
using Sportradar.Mbs.Sdk.Protocol;

namespace Sportradar.Mbs.Sdk.Internal.Protocol;

internal partial class ProtocolProvider : ITicketProtocol
{
    internal ITicketProtocol TicketProtocol => this;

    public async Task<TicketResponse> SendTicketAsync(TicketRequest request)
    {
        return await ProcessRequestAsync<TicketResponse>("ticket-placement", request).ConfigureAwait(false);
    }

    public async Task<TicketInformResponse> SendTicketInformAsync(TicketInformRequest request)
    {
        return await ProcessRequestAsync<TicketInformResponse>("ticket-placement-inform", request).ConfigureAwait(false);
    }

    public async Task<TicketAckResponse> SendTicketAckAsync(TicketAckRequest request)
    {
        return await ProcessRequestAsync<TicketAckResponse>("ticket-placement-ack", request).ConfigureAwait(false);
    }

    public async Task<CancelResponse> SendCancelAsync(CancelRequest request)
    {
        return await ProcessRequestAsync<CancelResponse>("ticket-cancel", request).ConfigureAwait(false);
    }

    public async Task<CancelAckResponse> SendCancelAckAsync(CancelAckRequest request)
    {
        return await ProcessRequestAsync<CancelAckResponse>("ticket-cancel-ack", request).ConfigureAwait(false);
    }

    public async Task<CashoutResponse> SendCashoutAsync(CashoutRequest request)
    {
        return await ProcessRequestAsync<CashoutResponse>("ticket-cashout", request).ConfigureAwait(false);
    }

    public async Task<CashoutAckResponse> SendCashoutAckAsync(CashoutAckRequest request)
    {
        return await ProcessRequestAsync<CashoutAckResponse>("ticket-cashout-ack", request).ConfigureAwait(false);
    }

    public async Task<ExtSettlementResponse> SendExtSettlementAsync(ExtSettlementRequest request)
    {
        return await ProcessRequestAsync<ExtSettlementResponse>("ticket-ext-settlement", request).ConfigureAwait(false);
    }

    public async Task<ExtSettlementAckResponse> SendExtSettlementAckAsync(ExtSettlementAckRequest request)
    {
        return await ProcessRequestAsync<ExtSettlementAckResponse>("ticket-ext-settlement-ack", request).ConfigureAwait(false);
    }
}

using Sportradar.Mbs.Sdk.Entities.Request;
using Sportradar.Mbs.Sdk.Entities.Response;
using Sportradar.Mbs.Sdk.Protocol;

namespace Sportradar.Mbs.Sdk.Internal.Protocol;

internal partial class ProtocolProvider : IAccountProtocol
{
    internal IAccountProtocol AccountProtocol => this;

    public async Task<AccountStatusInformResponse> SendAccountStatusInformAsync(AccountStatusInformRequest request)
    {
        return await ProcessRequestAsync<AccountStatusInformResponse>("account-status-inform", request).ConfigureAwait(false);
    }

    public async Task<FinancialLimitInformResponse> SendFinancialLimitInformAsync(FinancialLimitInformRequest request)
    {
        return await ProcessRequestAsync<FinancialLimitInformResponse>("financial-limit-inform", request).ConfigureAwait(false);
    }

    public async Task<SessionLimitInformResponse> SendSessionLimitInformAsync(SessionLimitInformRequest request)
    {
        return await ProcessRequestAsync<SessionLimitInformResponse>("session-limit-inform", request).ConfigureAwait(false);
    }

    public async Task<LimitReachedInformResponse> SendLimitReachedInformAsync(LimitReachedInformRequest request)
    {
        return await ProcessRequestAsync<LimitReachedInformResponse>("limit-reached-inform", request).ConfigureAwait(false);
    }
}

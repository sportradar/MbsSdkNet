using Sportradar.Mbs.Sdk.Protocol;

namespace Sportradar.Mbs.Sdk.Internal.Protocol;

internal class ProtocolProvider : IProtocolProvider
{
    internal ProtocolProvider(long operatorId, ProtocolEngine engine)
    {
        AccountProtocol = new AccountProtocol(operatorId, engine);
        BalanceProtocol = new BalanceProtocol(operatorId, engine);
        GamingProtocol = new GamingProtocol(operatorId, engine);
        TicketProtocol = new TicketProtocol(operatorId, engine);
    }
    
    public ITicketProtocol TicketProtocol { get; }
    public IAccountProtocol AccountProtocol { get; }
    public IBalanceProtocol BalanceProtocol { get; }
    public IGamingProtocol GamingProtocol { get; }
}
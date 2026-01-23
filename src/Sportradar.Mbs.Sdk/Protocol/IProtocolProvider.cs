namespace Sportradar.Mbs.Sdk.Protocol;

/// <summary>
/// Defines the contract for obtaining all the available protocols.
/// </summary>
public interface IProtocolProvider
{
    /// <summary>
    /// Gets the ticket protocol.
    /// </summary>
    public ITicketProtocol TicketProtocol { get; }

    /// <summary>
    /// Gets the account protocol.
    /// </summary>
    public IAccountProtocol AccountProtocol { get; }

    /// <summary>
    /// Gets the balance protocol.
    /// </summary>
    public IBalanceProtocol BalanceProtocol { get; }
    
    /// <summary>
    /// Gets the gaming protocol.
    /// </summary>
    public IGamingProtocol GamingProtocol { get; }
}
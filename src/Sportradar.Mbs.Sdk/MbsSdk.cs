using System.Collections.Concurrent;
using Sportradar.Mbs.Sdk.Internal.Protocol;
using Sportradar.Mbs.Sdk.Internal.Utils;
using Sportradar.Mbs.Sdk.Protocol;

namespace Sportradar.Mbs.Sdk;

/// <summary>
/// Represents the main class for interacting with the MBS service.
/// </summary>
public class MbsSdk : IProtocolProvider, IDisposable
{
    private readonly object _lock;
    private readonly ProtocolEngine _protocolEngine;
    private readonly Action<MbsSdk, Exception>? _unhandledExceptionHandler;
    private readonly ProtocolProvider _defaultProvider;
    private readonly ConcurrentDictionary<long, ProtocolProvider> _providers = new();

    private bool _connected;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="MbsSdk"/> class.
    /// </summary>
    /// <param name="config">The configuration for the SDK.</param>
    public MbsSdk(MbsSdkConfig config)
    {
        _unhandledExceptionHandler = config.UnhandledExceptionHandler;
        _protocolEngine = new ProtocolEngine(config);
        _defaultProvider = new ProtocolProvider(config.OperatorId, _protocolEngine);
        _providers[config.OperatorId] = _defaultProvider;
        _protocolEngine.UnhandledException += ProtocolOnUnhandledException;
        _lock = new object();
    }

    /// <summary>
    /// Gets the ticket protocol.
    /// </summary>
    public ITicketProtocol TicketProtocol => _defaultProvider.TicketProtocol;

    /// <summary>
    /// Gets the account protocol.
    /// </summary>
    public IAccountProtocol AccountProtocol => _defaultProvider.AccountProtocol;

    /// <summary>
    /// Gets the balance protocol.
    /// </summary>
    public IBalanceProtocol BalanceProtocol => _defaultProvider.BalanceProtocol;

    /// <summary>
    /// Gets the gaming protocol.
    /// </summary>
    public IGamingProtocol GamingProtocol => _defaultProvider.GamingProtocol;
    
    /// <summary>
    /// Gets the protocol provider for the specified operator ID.
    /// </summary>
    /// <param name="operatorId">The operator ID.</param>
    /// <returns>The protocol provider for the specified operator ID.</returns>
    public IProtocolProvider GetProtocolProvider(long operatorId) {
        return _providers.GetOrAdd(operatorId, oId => new ProtocolProvider(oId, _protocolEngine));
    }
    
    /// <summary>
    /// Disposes the SDK and releases all resources.
    /// </summary>
    public void Dispose()
    {
        lock (_lock)
        {
            if (_disposed) return;

            _disposed = true;
            ExcSuppress.Dispose(_protocolEngine);
        }
    }

    /// <summary>
    /// Connects to the MBS service.
    /// </summary>
    public void Connect()
    {
        lock (_lock)
        {
            if (_disposed) throw new ObjectDisposedException(nameof(MbsSdk));
            if (_connected) return;
            Task.Run(_protocolEngine.Connect).Wait();
            _connected = true;
        }
    }

    /// <summary>
    /// Handles unhandled exceptions from the protocol provider.
    /// </summary>
    private void ProtocolOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        try
        {
            _unhandledExceptionHandler?.Invoke(this, (e.ExceptionObject as Exception)!);
        }
        catch
        {
        }
    }
}
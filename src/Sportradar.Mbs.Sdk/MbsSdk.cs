using Sportradar.Mbs.Sdk.Internal.Protocol;
using Sportradar.Mbs.Sdk.Internal.Utils;
using Sportradar.Mbs.Sdk.Protocol;

namespace Sportradar.Mbs.Sdk;

/// <summary>
/// Represents the main class for interacting with the MBS service.
/// </summary>
public class MbsSdk : IDisposable
{
    private readonly object _lock;
    private readonly ProtocolProvider _protocolProvider;
    private readonly Action<MbsSdk, Exception>? _unhandledExceptionHandler;

    private bool _connected;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="MbsSdk"/> class.
    /// </summary>
    /// <param name="config">The configuration for the SDK.</param>
    public MbsSdk(MbsSdkConfig config)
    {
        _unhandledExceptionHandler = config.UnhandledExceptionHandler;
        _protocolProvider = new ProtocolProvider(config);
        _protocolProvider.UnhandledException += ProtocolProviderOnUnhandledException;
        _lock = new object();
    }

    /// <summary>
    /// Gets the ticket protocol.
    /// </summary>
    public ITicketProtocol TicketProtocol => _protocolProvider.TicketProtocol;

    /// <summary>
    /// Gets the account protocol.
    /// </summary>
    public IAccountProtocol AccountProtocol => _protocolProvider.AccountProtocol;

    /// <summary>
    /// Gets the balance protocol.
    /// </summary>
    public IBalanceProtocol BalanceProtocol => _protocolProvider.BalanceProtocol;

    /// <summary>
    /// Disposes the SDK and releases all resources.
    /// </summary>
    public void Dispose()
    {
        lock (_lock)
        {
            if (_disposed) return;

            _disposed = true;
            ExcSuppress.Dispose(_protocolProvider);
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
            Task.Run(_protocolProvider.Connect).Wait();
            _connected = true;
        }
    }

    /// <summary>
    /// Handles unhandled exceptions from the protocol provider.
    /// </summary>
    private void ProtocolProviderOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
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
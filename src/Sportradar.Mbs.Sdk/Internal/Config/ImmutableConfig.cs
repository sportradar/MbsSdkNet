using Sportradar.Mbs.Sdk.Internal.Utils;

namespace Sportradar.Mbs.Sdk.Internal.Config;

internal class ImmutableConfig :
    IWebSocketConnectionConfig,
    ITokenProviderConfig,
    IConnectionProviderConfig,
    IProtocolProviderConfig
{
    private static readonly TimeSpan MinTimeSpan = TimeSpan.FromMilliseconds(1);

    internal ImmutableConfig(MbsSdkConfig parent)
    {
        ProtocolOperatorId = parent.OperatorId;
        AuthServer = parent.AuthServer.NotNull(nameof(AuthServer));
        AuthClientId = parent.AuthClientId.NotNull(nameof(AuthClientId));
        AuthClientSecret = parent.AuthClientSecret.NotNull(nameof(AuthClientSecret));
        AuthAudience = parent.AuthAudience.NotNull(nameof(AuthAudience));
        WsServer = parent.WsServer.NotNull(nameof(WsServer));
        AuthRequestTimeout =
            (parent.AuthRequestTimeout ?? TimeSpan.FromSeconds(5)).AtLeast(MinTimeSpan);
        AuthRetryDelay =
            (parent.AuthRetryDelay ?? TimeSpan.FromMilliseconds(500)).AtLeast(MinTimeSpan);
        WsNumberOfConnections =
            (parent.WsNumberOfConnections ?? 1).AtLeast(1);
        WsReconnectTimeout =
            (parent.WsReconnectTimeout ?? TimeSpan.FromSeconds(10)).AtLeast(MinTimeSpan);
        WsFetchMessageTimeout =
            (parent.WsFetchMessageTimeout ?? TimeSpan.FromSeconds(2)).AtLeast(MinTimeSpan);
        WsSendMessageTimeout =
            (parent.WsSendMessageTimeout ?? TimeSpan.FromSeconds(1)).AtLeast(MinTimeSpan);
        WsReceiveMessageTimeout =
            (parent.WsReceiveMessageTimeout ?? TimeSpan.FromMinutes(110)).AtLeast(MinTimeSpan);
        WsConsumerGraceTimeout =
            (parent.WsConsumerGraceTimeout ?? TimeSpan.FromMinutes(10)).AtLeast(MinTimeSpan);
        WsRefreshConnectionTimeout =
            (parent.WsRefreshConnectionTimeout ?? TimeSpan.FromMinutes(100)).AtLeast(MinTimeSpan);
        ProtocolRetryCount =
            (parent.ProtocolRetryCount ?? 0).AtLeast(0);
        ProtocolMaxSendBufferSize =
            (parent.ProtocolMaxSendBufferSize ?? 1_000).AtLeast(1);
        ProtocolConnectTimeout =
            (parent.ProtocolConnectTimeout ?? TimeSpan.FromSeconds(15)).AtLeast(MinTimeSpan);
        ProtocolReceiveResponseTimeout =
            (parent.ProtocolReceiveResponseTimeout ?? TimeSpan.FromSeconds(20)).AtLeast(MinTimeSpan);
        ProtocolEnqueueTimeout =
            (parent.ProtocolEnqueueTimeout ?? TimeSpan.FromMilliseconds(100)).AtLeast(MinTimeSpan);
        ProtocolDequeueTimeout =
            (parent.ProtocolDequeueTimeout ?? TimeSpan.FromSeconds(2)).AtLeast(MinTimeSpan);
        ProtocolNumberOfDispatchers =
            (parent.ProtocolNumberOfDispatchers ?? 1).AtLeast(1);
    }

    public int WsNumberOfConnections { get; }

    public TimeSpan ProtocolConnectTimeout { get; }
    public TimeSpan ProtocolEnqueueTimeout { get; }
    public TimeSpan ProtocolDequeueTimeout { get; }
    public TimeSpan ProtocolReceiveResponseTimeout { get; }
    public int ProtocolMaxSendBufferSize { get; }
    public long ProtocolOperatorId { get; }
    public int ProtocolRetryCount { get; }
    public int ProtocolNumberOfDispatchers { get; }

    public Uri AuthServer { get; }
    public string AuthClientId { get; }
    public string AuthClientSecret { get; }
    public string AuthAudience { get; }
    public TimeSpan AuthRequestTimeout { get; }
    public TimeSpan AuthRetryDelay { get; }
    public Uri WsServer { get; }
    public TimeSpan WsReconnectTimeout { get; }
    public TimeSpan WsFetchMessageTimeout { get; }
    public TimeSpan WsSendMessageTimeout { get; }
    public TimeSpan WsReceiveMessageTimeout { get; }
    public TimeSpan WsConsumerGraceTimeout { get; }
    public TimeSpan WsRefreshConnectionTimeout { get; }
}

using Sportradar.Mbs.Sdk.Internal.Connection.Messages.Base;

namespace Sportradar.Mbs.Sdk.Internal.Connection.Messages;

internal class SendWsInputMessage : WsInputMessage
{
  private volatile bool _suppressed = false;

  public SendWsInputMessage(string correlationId, List<byte[]> content)
    : base(correlationId)
  {
    Content = content;
  }

  internal List<byte[]> Content { get; }

  internal bool IsSuppressed { get { return _suppressed; } }

  internal void SuppressSend()
  {
    _suppressed = true;
  }
}
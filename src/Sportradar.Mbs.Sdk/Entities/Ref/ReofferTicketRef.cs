using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Ref;

/// <summary>
/// Represents a reoffer ticket reference.
/// </summary>
public class ReofferTicketRef : TicketRefBase
{
    [JsonInclude]
    [JsonPropertyName("type")]
    private string Type => "reoffer";

    /// <summary>
    /// Gets or sets the ticket ID.
    /// </summary>
    [JsonPropertyName("ticketId")]
    public string? TicketId { get; set; }

    /// <summary>
    /// Gets or sets the ticket signature.
    /// </summary>
    [JsonPropertyName("ticketSignature")]
    public string? TicketSignature { get; set; }
}

using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Ref;

/// <summary>
/// Represents an alternative stake ticket reference.
/// </summary>
public class AltStakeTicketRef : TicketRefBase
{
    [JsonInclude]
    [JsonPropertyName("type")]
    private string Type => "alt-stake";

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

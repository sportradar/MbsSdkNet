using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

/// <summary>
/// Represents a max stake request.
/// </summary>
public class MaxStakeRequest : ContentRequestBase
{
    [JsonInclude]
    [JsonPropertyName("type")]
    private string Type  => "max-stake";

    /// <summary>
    /// Gets or sets the ticket request.
    /// </summary>
    [JsonPropertyName("ticket")]
    public TicketRequest? Ticket { get; set; }
}

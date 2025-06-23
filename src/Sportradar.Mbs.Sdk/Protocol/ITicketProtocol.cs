using Sportradar.Mbs.Sdk.Entities.Request;
using Sportradar.Mbs.Sdk.Entities.Response;

namespace Sportradar.Mbs.Sdk.Protocol;

/// <summary>
/// Defines the methods for interacting with the ticket protocol.
/// </summary>
public interface ITicketProtocol
{
    /// <summary>
    /// Sends a ticket request asynchronously.
    /// </summary>
    /// <param name="request">The ticket request to send.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the ticket response.</returns>
    /// <exception cref="SdkException">Thrown when operation has failed.</exception>
    Task<TicketResponse> SendTicketAsync(TicketRequest request);

    /// <summary>
    /// Sends a ticket inform request asynchronously.
    /// </summary>
    /// <param name="request">The ticket inform request to send.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the ticket inform response.</returns>
    /// <exception cref="SdkException">Thrown when operation has failed.</exception>
    Task<TicketInformResponse> SendTicketInformAsync(TicketInformRequest request);

    /// <summary>
    /// Sends a ticket acknowledgement request asynchronously.
    /// </summary>
    /// <param name="request">The ticket acknowledgement request to send.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the ticket acknowledgement response.</returns>
    /// <exception cref="SdkException">Thrown when operation has failed.</exception>
    Task<TicketAckResponse> SendTicketAckAsync(TicketAckRequest request);

    /// <summary>
    /// Sends a cancel request asynchronously.
    /// </summary>
    /// <param name="request">The cancel request to send.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the cancel response.</returns>
    /// <exception cref="SdkException">Thrown when operation has failed.</exception>
    Task<CancelResponse> SendCancelAsync(CancelRequest request);

    /// <summary>
    /// Sends a cancel acknowledgement request asynchronously.
    /// </summary>
    /// <param name="request">The cancel acknowledgement request to send.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the cancel acknowledgement response.</returns>
    /// <exception cref="SdkException">Thrown when operation has failed.</exception>
    Task<CancelAckResponse> SendCancelAckAsync(CancelAckRequest request);

    /// <summary>
    /// Sends a cashout inform request asynchronously.
    /// </summary>
    /// <param name="request">The cashout inform request to send.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the cashout inform response.</returns>
    /// <exception cref="SdkException">Thrown when operation has failed.</exception>
    Task<CashoutInformResponse> SendCashoutInformAsync(CashoutInformRequest request);
    
    /// <summary>
    /// Sends a cashout request asynchronously.
    /// </summary>
    /// <param name="request">The cashout request to send.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the cashout response.</returns>
    /// <exception cref="SdkException">Thrown when operation has failed.</exception>
    Task<CashoutResponse> SendCashoutAsync(CashoutRequest request);

    /// <summary>
    /// Sends a cashout acknowledgement request asynchronously.
    /// </summary>
    /// <param name="request">The cashout acknowledgement request to send.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the cashout acknowledgement response.</returns>
    /// <exception cref="SdkException">Thrown when operation has failed.</exception>
    Task<CashoutAckResponse> SendCashoutAckAsync(CashoutAckRequest request);

    /// <summary>
    /// Sends a cashout build request asynchronously.
    /// </summary>
    /// <param name="request">The cashout build request to send.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the cashout build response.</returns>
    /// <exception cref="SdkException">Thrown when operation has failed.</exception>
    Task<CashoutBuildResponse> SendCashoutBuildAsync(CashoutBuildRequest request);    
    
    /// <summary>
    /// Sends a cashout placement request asynchronously.
    /// </summary>
    /// <param name="request">The cashout placement request to send.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the cashout placement response.</returns>
    /// <exception cref="SdkException">Thrown when operation has failed.</exception>
    Task<CashoutPlacementResponse> SendCashoutPlacementAsync(CashoutPlacementRequest request);
    
    /// <summary>
    /// Sends an external settlement request asynchronously.
    /// </summary>
    /// <param name="request">The external settlement request to send.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the external settlement response.</returns>
    /// <exception cref="SdkException">Thrown when operation has failed.</exception>
    Task<ExtSettlementResponse> SendExtSettlementAsync(ExtSettlementRequest request);

    /// <summary>
    /// Sends an external settlement acknowledgement request asynchronously.
    /// </summary>
    /// <param name="request">The external settlement acknowledgement request to send.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the external settlement acknowledgement response.</returns>
    /// <exception cref="SdkException">Thrown when operation has failed.</exception>
    Task<ExtSettlementAckResponse> SendExtSettlementAckAsync(ExtSettlementAckRequest request);

    /// <summary>
    /// Sends a max stake request asynchronously.
    /// </summary>
    /// <param name="request">The max stake request to send.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the max stake response.</returns>
    /// <exception cref="SdkException">Thrown when operation has failed.</exception>
    Task<MaxStakeResponse> SendMaxStakeAsync(MaxStakeRequest request);
}
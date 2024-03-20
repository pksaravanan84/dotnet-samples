using Azure.Storage.Queues.Models;

namespace Azure.Blob.Web.Sample.Models
{
    public interface IQueueStorage
    {
        Task WriteMessage(string message);
        Task<QueueMessage> ReadMessage();
        Task<PeekedMessage> PeekMessage();
    }
}

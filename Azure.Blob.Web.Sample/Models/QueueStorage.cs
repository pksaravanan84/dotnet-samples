using Azure.Storage.Blobs;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.Extensions.Options;

namespace Azure.Blob.Web.Sample.Models
{
    public class QueueStorage : IQueueStorage
    {
        private readonly AzureStorageConfig storageConfig;


        public QueueStorage(IOptions<AzureStorageConfig> storageConfig)
        {
            this.storageConfig = storageConfig.Value;
        }
        public Task Initialize()
        {
            QueueClient queueClient = new QueueClient(storageConfig.ConnectionString, "pksqueuedemo");
            return Task.CompletedTask;
        }

        public async Task<PeekedMessage> PeekMessage()
        {
            QueueClient queueClient = new QueueClient(storageConfig.ConnectionString, "pksqueuedemo");
            return await queueClient.PeekMessageAsync();
        }

        public async Task<QueueMessage> ReadMessage()
        {
            QueueClient queueClient = new QueueClient(storageConfig.ConnectionString, "pksqueuedemo");
            var message = await queueClient.ReceiveMessageAsync();
            return message;
        }

        public async Task WriteMessage(string message)
        {
            QueueClient queueClient = new QueueClient(storageConfig.ConnectionString, "pksqueuedemo");
            await queueClient.SendMessageAsync(message);
        }
    }
}

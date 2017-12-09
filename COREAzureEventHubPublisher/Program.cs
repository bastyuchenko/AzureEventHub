using Microsoft.ServiceBus.Messaging;
using System;
using System.Text;

namespace COREAzureEventHubPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            EventHubClient client = EventHubClient.CreateFromConnectionString("Endpoint=sb://testgiteventhub.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=GotpcwuPgGsRLrKdAqSCdiK/yxcoqGIqrGNzw8yityc=");

            client.Send(new EventData(Encoding.UTF8.GetBytes("Hello part key 1"))
            {
                PartitionKey = "PartitionKey1"
            });

            client.Send(new EventData(Encoding.UTF8.GetBytes("Hello part key 2"))
            {
                PartitionKey = "PartitionKey2"
            });

            client.Send(new EventData(Encoding.UTF8.GetBytes("Hello part key 3"))
            {
                PartitionKey = "PartitionKey3"
            });

            client.Send(new EventData(Encoding.UTF8.GetBytes("Hello part key 4"))
            {
                PartitionKey = "PartitionKey4"
            });

            client.Send(new EventData(Encoding.UTF8.GetBytes("Hello part key 5"))
            {
                PartitionKey = "PartitionKey5"
            });
        }
    }
}

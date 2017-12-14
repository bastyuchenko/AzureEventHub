using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkAzureEventHubPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            EventHubClient client = EventHubClient.CreateFromConnectionString("Endpoint=sb://ehtest8.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=321/mX76iZUY6GtRBYYp9nzXrspGaS/mP/EZthSteS8=", "ehone");

            for (int i = 0; i < 5; i++)
            {
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
}
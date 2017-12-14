using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

namespace FrameworkAzureEventHubConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
//            EventHubClient client = EventHubClient.CreateFromConnectionString("Endpoint=sb://ehtest8.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=321/mX76iZUY6GtRBYYp9nzXrspGaS/mP/EZthSteS8=", "ehone");


//            EventHubConsumerGroup group = client.GetDefaultConsumerGroup();
//            var receiver = group.CreateReceiver(client.GetRuntimeInformation().PartitionIds[0]);

//bool receive = true;
//            string myOffset;
//            while (receive)
//            {
//                var message = receiver.Receive();
//                myOffset = message.Offset;
//                string body = Encoding.UTF8.GetString(message.GetBytes());
//                Console.WriteLine(String.Format("Received message offset: {0} \nbody: {1}", myOffset, body));
//            }

            EventProcessorHost eventProcessorHost = new EventProcessorHost("ehph","ehone", EventHubConsumerGroup.DefaultGroupName, "Endpoint=sb://ehtest8.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=321/mX76iZUY6GtRBYYp9nzXrspGaS/mP/EZthSteS8=", "DefaultEndpointsProtocol=https;AccountName=ehstrorage;AccountKey=Swt9Xx2vx98u4riTSHkW0rmFX4tP9mhTZman1YfgczBcdFa0lykdb+hoVWlxL0pyna2O6hkFxjKVd8l5CsOcDA==;EndpointSuffix=core.windows.net");

            eventProcessorHost.RegisterEventProcessorAsync<MyEventProcessor>().Wait();

            Thread.Sleep(TimeSpan.FromMinutes(1));
        }
    }

    public class MyEventProcessor : IEventProcessor
    {
        public Task CloseAsync(PartitionContext context, CloseReason reason)
        {
            return Task.FromResult<object>(null);
        }

        public Task OpenAsync(PartitionContext context)
        {
            return Task.FromResult<object>(null);
        }

        public Task ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages)
        {
            
            foreach (var item in messages)
            {
                Console.WriteLine($"{context.Lease.PartitionId }*****{Encoding.UTF8.GetString(item.GetBytes())}");
            }

            return Task.FromResult<object>(null);
        }
    }
}

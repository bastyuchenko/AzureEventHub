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
        const string PropertyName = "DataInfo";

        static void Main(string[] args)
        {
            EventHubClient client = EventHubClient.CreateFromConnectionString("Endpoint=sb://ehtest8.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=321/mX76iZUY6GtRBYYp9nzXrspGaS/mP/EZthSteS8=", "ehone");

            for (int i = 0; i < 5; i++)
            {
                client.Send(MakeMessage("1"));

                client.Send(MakeMessage("2"));

                client.Send(MakeMessage("3"));

                client.Send(MakeMessage("4"));

                client.Send(MakeMessage("5"));
            }
        }

        private static EventData MakeMessage(string partitionKeyNumber)
        {
            var ed = new EventData(Encoding.UTF8.GetBytes("Hello part key "+ partitionKeyNumber))
            {
                PartitionKey = "PartitionKey"+ partitionKeyNumber,
            };

            ed.Properties.Add(PropertyName, new MyProperties()
            {
                Author = "Anton Bastiuchenko",
                VersionNumber = Int32.Parse(partitionKeyNumber),
                Organization = "Test LLC"
            });

            return ed;
        }
    }


    internal class MyProperties
    {
        public string Author { get; set; }
        public int VersionNumber { get; set; }
        public string Organization { get; set; }
    }
}
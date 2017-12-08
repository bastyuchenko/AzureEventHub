using Microsoft.ServiceBus.Messaging;
using System;

namespace COREAzureEventHubPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            EventHubClient client = EventHubClient.CreateFromConnectionString("Endpoint=sb://testgiteventhub.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=GotpcwuPgGsRLrKdAqSCdiK/yxcoqGIqrGNzw8yityc=");
        }
    }
}

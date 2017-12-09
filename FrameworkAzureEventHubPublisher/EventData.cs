namespace FrameworkAzureEventHubPublisher
{
    internal class EventData
    {
        private byte[] v;

        public EventData(byte[] v)
        {
            this.v = v;
        }

        public string PartitionKey { get; set; }
    }
}
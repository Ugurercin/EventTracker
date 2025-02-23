namespace EventTracker.Kafka.Producer
{
    public class KafkaProducerConfig
    {
        public string BootstrapServers { get; set; } = "localhost:9092";
        public string Topic { get; set; } = "orders";
    }
}

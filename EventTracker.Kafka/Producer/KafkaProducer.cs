
using System.Text.Json;
using Confluent.Kafka;
using Microsoft.Extensions.Options;


namespace EventTracker.Kafka.Producer
{
    public class KafkaProducer
    {
        private readonly IProducer<string, string> _producer;
        private readonly string _topic;

        public KafkaProducer(IOptions<KafkaProducerConfig> kafkaOptions)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = kafkaOptions.Value.BootstrapServers
            };

            _topic = kafkaOptions.Value.Topic;
            _producer = new ProducerBuilder<string, string>(config).Build();
        }

        public async Task ProduceAsync<T>(string key, T message)
        {
            var jsonMessage = JsonSerializer.Serialize(message);
            await _producer.ProduceAsync(_topic, new Message<string, string>
            {
                Key = key,
                Value = jsonMessage
            });

            Console.WriteLine($"[Kafka Producer] Sent message to '{_topic}': {jsonMessage}");
        }
    }
}

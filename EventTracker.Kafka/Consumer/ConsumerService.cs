using Microsoft.Extensions.Hosting;

namespace EventTracker.Kafka.Consumer
{
    public class ConsumerService : IHostedService
    {
        private readonly KafkaConsumer _kafkaConsumer;

        public ConsumerService(KafkaConsumer kafkaConsumer)
        {
            _kafkaConsumer = kafkaConsumer;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("[ConsumerService] Starting Kafka Consumer...");
            _kafkaConsumer.Start();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("[ConsumerService] Stopping Kafka Consumer...");
            _kafkaConsumer.Stop();
            return Task.CompletedTask;
        }
    }
}

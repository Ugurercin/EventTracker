using Confluent.Kafka;
using Microsoft.Extensions.Hosting;

namespace EventTracker.Kafka.Consumer
{
    public class KafkaConsumer
    {
        private readonly string _topic = "orders";
        private readonly string _bootstrapServers = "localhost:9092";
        private readonly string _groupId = "order-consumer-group";
        private IConsumer<string, string> _consumer;
        private Task _consumerTask;
        private CancellationTokenSource _cancellationTokenSource;

        public KafkaConsumer()
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = _bootstrapServers,
                GroupId = _groupId,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = true
            };
            _consumer = new ConsumerBuilder<string, string>(config).Build();
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void Start()
        {
            Console.WriteLine("[Kafka Consumer] Starting...");
            _consumerTask = Task.Run(() => ConsumeMessages(_cancellationTokenSource.Token));
        }

        private void ConsumeMessages(CancellationToken stoppingToken)
        {
            _consumer.Subscribe(_topic);
            Console.WriteLine($"[Kafka Consumer] Listening to topic: {_topic}");

            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    try
                    {
                        var consumeResult = _consumer.Consume(stoppingToken);
                        Console.WriteLine($"[Kafka Consumer] Received message: {consumeResult.Message.Value}");
                    }
                    catch (ConsumeException e)
                    {
                        Console.WriteLine($"[Kafka Consumer] Error consuming message: {e.Error.Reason}");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("[Kafka Consumer] Consumer stopped.");
            }
            finally
            {
                _consumer.Close();
            }
        }

        public void Stop()
        {
            Console.WriteLine("[Kafka Consumer] Stopping...");
            _cancellationTokenSource.Cancel();
            _consumerTask?.Wait();
            _consumer.Dispose();
        }


    }
}

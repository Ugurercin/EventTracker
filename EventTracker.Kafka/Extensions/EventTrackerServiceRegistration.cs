using EventTracker.Kafka.Consumer;
using EventTracker.Kafka.Producer;
using Microsoft.Extensions.DependencyInjection;

namespace EventTracker.Kafka.Extensions
{
    public static class EventTrackerServiceRegistration
    {
        public static IServiceCollection AddKafkaServices(this IServiceCollection services)
        {
            services.AddSingleton<KafkaConsumer>();
            services.AddHostedService<ConsumerService>();
            services.AddSingleton<KafkaProducer>();
         
            //services.AddHostedService<KafkaConsumer>(); Swagger never loads because the app is "stuck" running the Kafka Consumer.
            return services;
        }
    }
}

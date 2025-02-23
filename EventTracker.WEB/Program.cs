using EventTracker.Kafka.Extensions;
using EventTracker.Kafka.Producer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<KafkaProducerConfig>(builder.Configuration.GetSection("Kafka"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddKafkaServices();

var app = builder.Build();

Console.WriteLine("API Starting...");

// ✅ Enable Swagger
if (app.Environment.IsDevelopment())
{
    Console.WriteLine("Swagger is enabled.");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

// ✅ Start API
Console.WriteLine("API is running on http://localhost:5000");
app.Run();

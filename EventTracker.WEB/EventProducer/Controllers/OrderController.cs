
using EventTracker.Kafka.Producer;
using Microsoft.AspNetCore.Mvc;


namespace EventTracker.WEB.EventProducer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly KafkaProducer _kafkaProducer;

        public OrderController(KafkaProducer kafkaProducer)
        {
            _kafkaProducer = kafkaProducer;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.OrderId))
                return BadRequest("Invalid order request.");

            await _kafkaProducer.ProduceAsync(request.OrderId, request);
            return Ok(new { message = "Order event sent to Kafka", orderId = request.OrderId });
        }
        public class OrderRequest
        {
            public string OrderId { get; set; } = Guid.NewGuid().ToString();
            public string ProductName { get; set; } = string.Empty;
            public int Quantity { get; set; }
        }
    }
}

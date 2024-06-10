using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQService.Services;

namespace RabbitMQService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMQController : ControllerBase
    {
        private readonly IRabbitMQService _rabbitMQService;

        public RabbitMQController(IRabbitMQService rabbitMQService)
        {
            _rabbitMQService = rabbitMQService;
        }

        [HttpPost("{queueName}")]
        public IActionResult SendMessage(string queueName, [FromBody] string message)
        {
            _rabbitMQService.SendMessage(queueName, message);
            return Ok();
        }
    }
}

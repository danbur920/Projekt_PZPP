using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Task.Models;
using Task.Services.Interfaces;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly HttpClient _httpClient;

        public TaskController(ITaskService taskService, IHttpClientFactory httpClientFactory)
        {
            _taskService = taskService;
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://rabbitmqservice:80");
        }

        [HttpGet]
        public async Task<IEnumerable<_Task>> GetAllTasks()
        {
            return await _taskService.GetAllTasksAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<_Task>> GetTaskById(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return task;
        }

        [HttpPost]
        public async Task<ActionResult<_Task>> CreateTask(_Task task)
        {
            var createdTask = await _taskService.CreateTaskAsync(task);

            var message = JsonSerializer.Serialize(new { action = "create", task = createdTask });
            var content = new StringContent(message, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/rabbitmq/task_queue", content);
            response.EnsureSuccessStatusCode();

            return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.Id }, createdTask);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, _Task task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            try
            {
                await _taskService.UpdateTaskAsync(task);

                var message = JsonSerializer.Serialize(new { action = "update", task });
                var content = new StringContent(message, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("api/rabbitmq/task_queue", content);
                response.EnsureSuccessStatusCode();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskService.DeleteTaskAsync(id);

            var message = JsonSerializer.Serialize(new { action = "delete", taskId = id });
            var content = new StringContent(message, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/rabbitmq/task_queue", content);
            response.EnsureSuccessStatusCode();

            return NoContent();
        }

        [HttpGet("byList/{listId}")]
        public async Task<IEnumerable<_Task>> GetTasksByListId(int listId)
        {
            return await _taskService.GetTasksByListIdAsync(listId);
        }
    }
}

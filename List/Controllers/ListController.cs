using List.Models;
using List.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace List.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly IListService _listService;
        private readonly HttpClient _rabbitMQClient;

        public ListController(IListService listService, IHttpClientFactory httpClientFactory)
        {
            _listService = listService;
            _rabbitMQClient = httpClientFactory.CreateClient();
            _rabbitMQClient.BaseAddress = new Uri("http://rabbitmqservice:80/api/rabbitmq");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLists()
        {
            var lists = await _listService.GetAllListsAsync();
            return Ok(lists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetListById(int id)
        {
            var list = await _listService.GetListByIdAsync(id);
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> CreateList(_List list)
        {
            if (list == null)
            {
                return BadRequest();
            }

            var createdList = await _listService.CreateListAsync(list);

            var message = JsonSerializer.Serialize(new { action = "create", list });
            var content = new StringContent(message, Encoding.UTF8, "application/json");
            var response = await _rabbitMQClient.PostAsync("task_queue", content);
            response.EnsureSuccessStatusCode();

            return CreatedAtAction(nameof(GetListById), new { id = createdList.Id }, createdList);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateList(int id, _List list)
        {
            if (id != list.Id || list == null)
            {
                return BadRequest();
            }

            var updatedList = await _listService.UpdateListAsync(list);

            var message = JsonSerializer.Serialize(new { action = "update", list });
            var content = new StringContent(message, Encoding.UTF8, "application/json");
            var response = await _rabbitMQClient.PostAsync("task_queue", content);
            response.EnsureSuccessStatusCode();

            return Ok(updatedList);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteList(int id)
        {
            await _listService.DeleteListAsync(id);

            var message = JsonSerializer.Serialize(new { action = "delete", taskId = id });
            var content = new StringContent(message, Encoding.UTF8, "application/json");
            var response = await _rabbitMQClient.PostAsync("task_queue", content);
            response.EnsureSuccessStatusCode();

            return NoContent();
        }

        [HttpGet("byBoard/{boardId}")]
        public async Task<IActionResult> GetListsByBoardId(int boardId)
        {
            var lists = await _listService.GetListsByBoardIdAsync(boardId);
            return Ok(lists);
        }
    }
}

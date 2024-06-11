using Board.Models;
using Board.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Board.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IBoardService _boardService;
        private readonly HttpClient _rabbitMQClient;

        public BoardController(IBoardService boardService, IHttpClientFactory httpClientFactory)
        {
            _boardService = boardService;
            _rabbitMQClient = httpClientFactory.CreateClient();
            _rabbitMQClient.BaseAddress = new Uri("http://rabbitmqservice:80/api/rabbitmq");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<_Board>>> GetAllBoards()
        {
            var boards = await _boardService.GetAllBoards();
            return Ok(boards);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<_Board>> GetBoardById(int id)
        {
            var board = await _boardService.GetBoardById(id);
            if (board == null)
            {
                return NotFound();
            }
            return Ok(board);
        }

        [HttpPost]
        public async Task<ActionResult> AddBoard([FromBody] _Board board)
        {
            if (board == null)
            {
                return BadRequest();
            }

            await _boardService.AddBoard(board);

            var message = JsonSerializer.Serialize(new { action = "add", board });
            var content = new StringContent(message, Encoding.UTF8, "application/json");
            var response = await _rabbitMQClient.PostAsync("board_queue", content);
            response.EnsureSuccessStatusCode();

            return CreatedAtAction(nameof(GetBoardById), new { id = board.Id }, board);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBoard(int id, [FromBody] _Board board)
        {
            if (board == null || board.Id != id)
            {
                return BadRequest();
            }

            var existingBoard = await _boardService.GetBoardById(id);
            if (existingBoard == null)
            {
                return NotFound();
            }

            await _boardService.UpdateBoard(board);

            var message = JsonSerializer.Serialize(new { action = "update", board });
            var content = new StringContent(message, Encoding.UTF8, "application/json");
            var response = await _rabbitMQClient.PostAsync("board_queue", content);
            response.EnsureSuccessStatusCode();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBoard(int id)
        {
            var existingBoard = await _boardService.GetBoardById(id);
            if (existingBoard == null)
            {
                return NotFound();
            }

            await _boardService.DeleteBoard(id);

            var message = JsonSerializer.Serialize(new { action = "delete", boardId = id });
            var content = new StringContent(message, Encoding.UTF8, "application/json");
            var response = await _rabbitMQClient.PostAsync("board_queue", content);
            response.EnsureSuccessStatusCode();

            return NoContent();
        }
    }
}

using Board.Models;
using Board.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Board.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IBoardService _boardService;

        public BoardController(IBoardService boardService)
        {
            _boardService = boardService;
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
            return NoContent();
        }
    }
}

using List.Models;
using List.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace List.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly IListService _listService;

        public ListController(IListService listService)
        {
            _listService = listService;
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
            return Ok(updatedList);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteList(int id)
        {
            await _listService.DeleteListAsync(id);
            return NoContent();
        }
    }
}

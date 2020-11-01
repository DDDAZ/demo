using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoListReview.Models;
using TodoListReview.Services;

namespace TodoListReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListReviewController : ControllerBase
    {
        private readonly ItemService _itemService;

        public TodoListReviewController(ItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Item>>> Get()
        {
            var items = await _itemService.Get();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> Search(long id)
        {
            var item = await _itemService.Get(id);

            if (item == null)
            {
                return NotFound($"No item match id: {id}");
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Item itemIn)
        {
            var item = await _itemService.Get(itemIn.Id);

            if (item != null)
            {
                return BadRequest($"Item match id: {itemIn.Id} have existed");
            }

            await _itemService.Add(itemIn);

            return Ok("Add success");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var item = await _itemService.Get(id);

            if (item == null)
            {
                return NotFound($"No item match id: {id}");
            }

            await _itemService.Delete(id);

            return Ok("Delete success");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Item>> Updete(long id, Item itemIn)
        {
            var item = await _itemService.Get(id);

            if (item == null)
            {
                return NotFound($"No item match id: {id}");
            }

            await _itemService.Update(id, itemIn);

            return Ok("Update success");
        }
    }
}

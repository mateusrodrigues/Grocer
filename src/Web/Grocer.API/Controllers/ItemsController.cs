using Grocer.Data;
using Grocer.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Grocer.Models;

namespace Grocer.API.Controllers
{
    [Route("api/Items")]
    [Produces("application/json")]
    public class ItemsController : Controller
    {
        private readonly ItemsRepository _itemsRepository;

        public ItemsController()
        {
            _itemsRepository = new ItemsRepository();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _itemsRepository.All());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var item = await _itemsRepository.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Item item)
        {
            var createdItem = await _itemsRepository.Create(item);

            return CreatedAtAction("Get", new { id = item.ItemID }, item);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var item = await _itemsRepository.Find(id.Value);

            if (item == null)
            {
                return NotFound();
            }

            await _itemsRepository.Delete(item);

            return NoContent();
        }
    }
}
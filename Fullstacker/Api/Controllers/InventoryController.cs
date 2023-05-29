using API.Dtos;
using DataLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Entities;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryController(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        /// <summary>
        /// An endpoint for retrieving a list of inventories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            var inventory = await _inventoryRepository.Get();

            if (inventory is null || !inventory.Any())
                return NotFound("No items found.");

            return Ok(inventory);
        }

        /// <summary>
        /// An endpoint for retrieving an inventory by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var inventory = await _inventoryRepository.Get(id);

            if (inventory is null)
                return NotFound($"No inventory found with id '{id}'");

            return Ok(inventory);
        }

        /// <summary>
        /// An endpoint for creating an inventory
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateInventoryDto request)
        {
            if (request.ItemId < 0 || request.Quantity < 0)
            {
                return BadRequest("Item ID or Quantity cannot be less than 0.");
            }

            var inventory = new Inventory
            {
                ItemId = request.ItemId,
                Quantity = request.Quantity
            };

            await _inventoryRepository.Create(inventory);

            return Ok();
        }

        /// <summary>
        /// An endpoint to delete an inventory
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _inventoryRepository.Delete(id);

            return Ok();
        }

        /// <summary>
        /// An endpoint to update an inventory
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateInvetoryDto request)
        {
            if (request.ItemId < 0 || request.Quantity < 0)
            {
                return BadRequest("Item ID or Quantity cannot be less than 0.");
            }

            await _inventoryRepository.Update(id, request.ItemId, request.Quantity);

            return Ok();
        }
    }
}


using API.Dtos;
using DataLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        /// An endpoint for retrieving a list of items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            var inventory = await _inventoryRepository.Get();

            return Ok(inventory);
        }

        /// <summary>
        /// An endpoint for retrieving an item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var inventory = await _inventoryRepository.Get(id);

            return Ok(inventory);
        }

        /// <summary>
        /// An endpoint to delete an item
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
        /// An endpoint to update an item
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateInvetoryDto request)
        {
            await _inventoryRepository.Update(id, request.ItemId, request.Quantity);

            return Ok();
        }

        /// <summary>
        /// An endpoint for creating an item
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateInventoryDto request)
        {
            var inventory = new DataLayer.Entities.Inventory
            {
                ItemId = request.ItemId,
                Quantity = request.Quantity
            };
            await _inventoryRepository.Create(inventory);

            return Ok();
        }
    }
}


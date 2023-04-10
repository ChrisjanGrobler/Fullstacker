using API.Dtos;
using DataLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ItemController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// An endpoint for retrieving a list of items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            var item = await _dataContext.Item.ToListAsync();

            return Ok(item);
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
            var item = await _dataContext.Item.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(item);
        }



        /// <summary>
        /// An endpoint for creating an item
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateItemDto request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var newItem = new DataLayer.Entities.Item{ 

                Name = request.Name ,
                Description = request.Description
            };

            _dataContext.Add(newItem);
            await _dataContext.SaveChangesAsync();

            return Ok(); // HTTP Status Code 200
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
            var item = _dataContext.Item.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            _dataContext.Item.Remove(item);
            await _dataContext.SaveChangesAsync();

            return NoContent();
        }


        /// <summary>
        /// An endpoint to update an item
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateItemDto request)//, [FromBody] UpdateItemDto request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var item = _dataContext.Item.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            item.Name = request.Name;
            item.Description = request.Description;

            _dataContext.Item.Update(item);
            await _dataContext.SaveChangesAsync();

            return Ok(item);
        }
    }

}
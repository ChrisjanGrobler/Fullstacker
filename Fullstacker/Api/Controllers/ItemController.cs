using API.Dtos;
using DataLayer.Contexts;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Get()
        {
            return Ok();
        }

        /// <summary>
        /// An endpoint for retrieving an item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get/{id}")]
        public IActionResult Get(int id)
        {
            var item = _dataContext.Item.FirstOrDefault(x => x.Id == id);

            return Ok(item);
        }

        /// <summary>
        /// An endpoint for creating an item
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] CreateItemDto request)
        {
            return Ok(); // HTTP Status Code 200
        }

        /// <summary>
        /// An endpoint to delete an item
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }

        
        /// <summary>
        /// An endpoint to update an item
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update/{id}")]
        public IActionResult Update([FromQuery] int id, [FromBody] UpdateItemDto request)
        {
            return Ok(request); // HTTP Status Code 200
        }
    }

}
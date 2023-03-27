using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CreateItemDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
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
    }
}

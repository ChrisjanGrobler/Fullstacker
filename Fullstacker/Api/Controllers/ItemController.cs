﻿using API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        /// <summary>
        /// An endpoint for retrieving a list of items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get")]
        public IActionResult Get()
        {
            var items = new List<GetItemDto>
            {
                new GetItemDto
            {
                Id = 1,
                Name = "Lip Ice",
                Description = "Self explanatory"
            },
                new GetItemDto
                {
                Id = 2,
                Name = "Dog Food",
                Description = ""
                }
            };

            return Ok(items);
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
            var item = new GetItemDto
            {
                Id = 1,
                Name = "Lip Ice",
                Description = "Self explanatory"
            };

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
    }
}
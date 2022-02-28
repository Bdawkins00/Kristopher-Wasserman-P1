using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LakeJacksonCyclingBL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LJCApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    
    public class ProductsController : ControllerBase
    {
        private readonly ILakeJacksonBL _repo;
        public ProductsController(ILakeJacksonBL p_name)
        {
            _repo = p_name;
        } 
        // GET: api/Products
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Products/5
        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            try
            {
                return Ok(_repo.GetAllProducts());
            }
            catch (Exception ex)
            {
                
             return StatusCode(422, ex.Message);
            }
        }

        // POST: api/Products
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

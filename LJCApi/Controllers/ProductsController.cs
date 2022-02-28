using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LakeJacksonCyclingBL;
<<<<<<< HEAD
using LakeJacksonCyclingModel;
=======
>>>>>>> edd5463860289d54b287f9d89f287334e1a2b6e1
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
<<<<<<< HEAD
        [HttpPost("AddProduct")]
        public  IActionResult AddProducts([FromQuery] Products p_name)
        { 
            try
            {
                return Created("Product has been added!",_repo.AddProduct(p_name));
            }
            catch (Exception ex)
            {
                
                return StatusCode(422,ex.Message);
            }
        }

        [HttpGet("GetProductsByStoreID")]
        public  IActionResult AddProductsByStoreID([FromQuery] int storeid)
        { 
            try
            {
                return Ok(_repo.GetAllProductsByStoreID(storeid));
            }
            catch (Exception ex)
            {
                
                return StatusCode(422,ex.Message);
            }
        }
        // PUT: api/Products/5
        [HttpPut("ReplinishInventory")]
        public IActionResult ReplemishInventory([FromQuery] int storeid,[FromQuery] int productid,[FromQuery] int quantity)
        {
            try
            {
                return Ok(_repo.ReplemishInventory(storeid, productid,quantity));
            }
            catch (Exception ex)
            {
                
                return StatusCode(422, ex.Message);
            }
        }

        
=======
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
>>>>>>> edd5463860289d54b287f9d89f287334e1a2b6e1
    }
}

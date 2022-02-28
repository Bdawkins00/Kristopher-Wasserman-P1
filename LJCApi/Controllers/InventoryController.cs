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
    public class InventoryController : ControllerBase
    {
        private readonly ILakeJacksonBL _repo;
        public InventoryController(ILakeJacksonBL p_cInfoBL)
        {
            _repo = p_cInfoBL;
        } 
        // GET: api/Inventory
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Inventory/5
        [HttpGet("GetAllInventory")]
        public IActionResult GetAllInventory()
        {
            try
            {
                return Ok(_repo.GetAllInventory());
            }
            catch (Exception ex)
            {
                
                return StatusCode(422,ex.Message);
            }
        }

        // POST: api/Inventory
        [HttpGet("GetInventoryByStoreID")]
        public IActionResult GetInventoryByStoreID([FromBody] int storeid)
        {
            try
            {
                return Ok(_repo.GetAllInventoryByStoreId(storeid));
            }
            catch (Exception ex)
            {
                
                return StatusCode(422, ex.Message);
            }
        }
    }
}

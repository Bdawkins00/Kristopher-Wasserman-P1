using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using LakeJacksonCyclingBL;
using LakeJacksonCyclingModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LJCApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ILakeJacksonBL _repo;

        /// <summary>
        /// adds a customer via an api
        /// </summary>
        /// <param name="p_cInfoBL"></param>

        public CustomersController(ILakeJacksonBL p_cInfoBL)
        {
            _repo = p_cInfoBL;
        } 
        // GET: api/Customer
        [HttpGet("GetAllCustomers")]
        public IActionResult GetAllCustomers()
        {
            try
            {
                return Ok(_repo.GetAllCustomers());
            }
            catch (SqlException)
            {
                
                return NotFound();
            }
            
        }

        // GET: api/Customer/5
        [HttpGet("GetCustomerByID")]
        public IActionResult GetCustomer([FromQuery] int cId)
        {
            try
            {
                return Ok(_repo.GetCustomerById(cId));
            }
            catch (System.Exception)
            {
                
                return NotFound();
            }
        }

        // POST: api/Customer
        [HttpPost("Add")]
        public IActionResult AddCustomer([FromQuery] Customers p_Name)
        {
            try
            {
                return Created("Customer Added Successfully!", _repo.AddCustomer(p_Name));
            }
            catch (System.Exception ex)
            {
                
                return Conflict(ex.Message);
            }
        }
        [HttpGet("SearchCustomer")]
        public IActionResult SearchCustomer([FromQuery] string p_name)
        {
            try
            {
                return Ok(_repo.SearchCustomer(p_name));
            }
            catch (Exception ex)
            {
                
                return StatusCode(422, ex.Message);
            }
        }

        [HttpGet("GetCustomerHistory")]
        public IActionResult GetCustomerHistory([FromQuery]int customerID)
        {
            try
            {
                return Ok(_repo.GetCustomerHistory(customerID));
            }
            catch (Exception ex)
            {
                
                return StatusCode(422,ex.Message);
            }
        }
    }
}

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

        public List<Employee> eInfo = new List<Employee>();
        public CustomersController(ILakeJacksonBL p_cInfoBL)
        {
            _repo = p_cInfoBL; 
            
        }
        

       
        // GET: api/Customer
        [HttpGet("GetAllCustomers")]
        public IActionResult GetAllCustomers([FromQuery] Customers p_name,int eID, string password)
        {
            
            if(_repo.IsAdmin(eID,password) == true)
            {
                Log.Information(" @eID has accessed the GetAllCustomers Controller");
                try
                {
                    return Ok(_repo.GetAllCustomers());
                }
                catch (SqlException)
                {
                    
                    return NotFound();
                }
            }
            else
            {
                Log.Warning("User made an unauthoried access attempt");
                return StatusCode(401,"No access allowed for this user");
            }
            
        }

        // GET: api/Customer/5
        [HttpGet("GetCustomerByID")]
        public IActionResult GetCustomer([FromQuery] int cId)
        {
            Log.Information("User has accessed the GetCustomer Controller");
            try
            {
                return Ok(_repo.GetCustomerById(cId));
            }
            catch (Exception ex)
            {
                Log.Warning("Error was made: "+ ex.Message);
                return StatusCode(401, ex.Message);
            }
        }

        // POST: api/Customer
        [HttpPost("Add")]
        public IActionResult AddCustomer([FromQuery] Customers p_Name,int eID, string password)
        {
            if(_repo.IsAdmin(eID,password) == true)
            {
                try
                {
                    Log.Information("$username has accessed the AddCustomer Controller");
                    return Created("Customer Added Successfully!", _repo.AddCustomer(p_Name));
                }
                catch (System.Exception ex)
                {
                    Log.Information("User has accessed the GetCustomer Controller");
                    return Conflict(ex.Message);
                }
            }
            else
            {
                return StatusCode(401,"No autherized access");
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
        public IActionResult GetCustomerHistory([FromQuery]int customerID, int eID, string password)
        {
            if(_repo.IsAdmin(eID,password) == true)
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
            else
            {
                return StatusCode(401, "No autherized access");
            }
        }
    }
}

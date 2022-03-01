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
    public class AuthenController : ControllerBase
    {
        private readonly ILakeJacksonBL _repo;
        public AuthenController(ILakeJacksonBL p_eInfo)
        {
            _repo = p_eInfo;
        } 
        // GET: api/Authen
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Authen/5
        [HttpGet("Login")]
        public IActionResult Login(int eID, string password)
        {
            try
            {
                Log.Information("user has accessed login");
                return Ok(_repo.Employees(eID, password));
            }
            catch (Exception ex)
            {
                Log.Error("user has made an Error: " + ex.Message);
                return StatusCode(422,ex.Message);
            }
            
        }
    }
}

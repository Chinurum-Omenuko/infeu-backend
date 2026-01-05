using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using infeubackend.Services;
using infeubackend.Interfaces;
using Newtonsoft.Json.Linq;

namespace infeubackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FireController : ControllerBase
    {
        private readonly IFireService _fireService;
        public FireController(IFireService fireService)
        {
            _fireService = fireService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFires()
        {
            try
            {
                byte[] firesData = await _fireService.GetAllFires();
                if (firesData == null || firesData.Length == 0)
                {
                    return NotFound("No fires data available.");
                };
                string jsonString = Encoding.UTF8.GetString(firesData);
                return Ok(jsonString);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using dotnet03_web_blazor.Models;

namespace dotnet03_web_blazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class demoApiController : ControllerBase
    {

        [HttpGet("getall")]
        public ActionResult GetAllProduct()
        {
            return Ok(new List<string>() {"prod1","prod2" });
        }

    }
}
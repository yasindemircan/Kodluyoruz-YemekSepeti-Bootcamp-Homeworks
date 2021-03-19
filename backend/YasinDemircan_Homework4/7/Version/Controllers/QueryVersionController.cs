using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Version.Controllers
{
    [ApiVersion("1.0")]
     [Route("api/[controller]")]
    [ApiController]
    public class QueryVersionController: ControllerBase
    {
       [HttpGet, MapToApiVersion("1.1")]
        public IActionResult Get(){
            List<String> customers = new List<string>(){
                "QueryString",
                "V1.0"
            };
        return Ok(customers);
        }

       // [ApiVersion("1.0", Deprecated = true)]
        [HttpGet, MapToApiVersion("2.1")]
        public IActionResult GetV2(){
            List<String> customers = new List<string>(){
                "QueryString",
                "V2.0"
            };
        return Ok(customers);
        }  
    }
}

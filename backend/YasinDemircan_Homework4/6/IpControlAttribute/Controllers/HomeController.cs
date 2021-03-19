using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace IpControlAttribute.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(IpControlAttribute.Attribute.IpControlAttribute))]

    public class HomeController:ControllerBase
    {
        [HttpGet]
        public IActionResult Get(){
            List<String> home = new List<string>(){
                "HomeController",
                "Adress:192.168.1.1"
            };
        return Ok(home);
        }
    }
}

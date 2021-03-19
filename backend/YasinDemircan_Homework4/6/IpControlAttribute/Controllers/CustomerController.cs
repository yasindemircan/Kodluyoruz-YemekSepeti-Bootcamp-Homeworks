using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace IpControlAttribute.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(IpControlAttribute.Attribute.IpControlAttribute))]

    public class CustomerController:ControllerBase
    {
       [HttpGet]
        public IActionResult Get(){
            List<String> customers = new List<string>(){
                "CustomerCotroller",
                "Adress:192.168.1.1"
            };
        return Ok(customers);
        }
    }
}

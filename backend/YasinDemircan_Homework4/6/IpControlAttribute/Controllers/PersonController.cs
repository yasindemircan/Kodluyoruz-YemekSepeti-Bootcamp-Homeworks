using System;
using System.Collections.Generic;
using IpControlAttribute.Attribute;
using Microsoft.AspNetCore.Mvc;

namespace IpControlAttribute.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(IpControlAttribute.Attribute.IpControlAttribute))]
    public class PersonController:ControllerBase
    {
         [HttpGet]
       
        public IActionResult GetAction(){
            List<String> person = new List<string>(){
                "PersonController",
                "Adress:192.168.1.2"
            };
            
            return Ok(person);
        }
    }
}
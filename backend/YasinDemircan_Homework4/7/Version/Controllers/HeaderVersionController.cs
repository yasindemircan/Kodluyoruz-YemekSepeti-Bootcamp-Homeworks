using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Version.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HeaderVersionController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<HeaderVersionController> _logger;

        public HeaderVersionController(ILogger<HeaderVersionController> logger)
        {
            _logger = logger;
        }

         [ApiVersion("1.0")]
        // [MapToApiVersion("1.0")]
         // [Route("api/{v:apiVersion}/HeaderVersion")] 
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                //Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }


        //[ApiVersion("2.0")]
       // [MapToApiVersion("2.0")]
       //  [Route("api/{v:apiVersion}/HeaderVersion")] 
         [HttpGet]
        public IEnumerable<WeatherForecast> GetWeathers()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}

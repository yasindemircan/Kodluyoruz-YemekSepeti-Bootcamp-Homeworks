using System;
using Microsoft.AspNetCore.Mvc;

namespace hotels.API.Controllers
{
[Route("/")]
[ApiController]
[ApiVersion("1.0")]
    public class RootController:ControllerBase
    {
        [HttpGet(Name = nameof(GetRoot))]
        public IActionResult GetRoot(){
            var response = new {
                 href = Url.Link(nameof(GetRoot),null),
                  Info = new{
                      href = Url.Link(nameof(InfoController.GetInfo),null),
                  },
                  
                  Rooms = new
                {
                  href =  Url.Link(nameof(RoomsController.GetRooms),null)
                }
            };
            return Ok(response);
        }
    }
}

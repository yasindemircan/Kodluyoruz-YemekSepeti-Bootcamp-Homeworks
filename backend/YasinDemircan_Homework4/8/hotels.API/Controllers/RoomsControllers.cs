using System;
using System.Threading.Tasks;
using hotels.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace hotels.API.Controllers
{
     [Authorize]
[Route("/[controller]")]
[ApiController]
    public class RoomsController:ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomsController(IRoomService roomService){
            _roomService = roomService;
        }



        [HttpGet(Name = nameof(GetRooms))]
        public async Task<IActionResult> GetRooms(){
           //return Ok();
           var rooms = await _roomService.GetRoomsAsync();
           if(rooms == null)
                return NoContent();
            return Ok(rooms);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using hotels.API.Models.Derived;

namespace hotels.API.Services
{
     public interface IRoomService
    {
        Task<List<Room>> GetRoomsAsync();

        Task<Room> GetRoomAsync(Guid id);
    }
}

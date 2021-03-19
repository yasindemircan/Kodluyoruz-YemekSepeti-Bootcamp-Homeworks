using System;
using hotels.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace hotels.API.Contexts
{
    public class HotelApiDbContext:DbContext
    {
        public HotelApiDbContext(DbContextOptions options) : base(options){

        }
        public DbSet<RoomEntity> Rooms {get;set;}
        public DbSet<UserEntity> Users {get;set;}
    }
}

using System;
using hotels.API.Abstract;
namespace hotels.API.Models.Derived
{
    public class Room:Resource
    {
        public string Name { get; set; }
        public int Rate { get; set; }
    }
}

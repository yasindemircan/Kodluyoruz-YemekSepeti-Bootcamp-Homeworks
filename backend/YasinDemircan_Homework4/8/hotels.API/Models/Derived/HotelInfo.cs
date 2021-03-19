using System;
using hotels.API.Abstract;
namespace hotels.API.Models.Derived
{
    public class HotelInfo:Resource
    {
        public string Title { get; set; }
        public string Email { get; set; }
        public  string WebSite { get; set; }
        public HotelAddress Location { get; set; }
    }
}

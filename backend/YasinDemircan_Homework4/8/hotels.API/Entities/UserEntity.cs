using System;
using System.Reflection.Emit;
namespace hotels.API.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string SurName { get; set; }
        public string LoginName { get; set; }
        public string Pass { get; set; }
        public string Phone { get; set; }
    }
}

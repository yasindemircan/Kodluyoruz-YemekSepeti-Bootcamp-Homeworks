using System;
using Domain.Interface;

namespace Domain.Entities
{
    public class Teacher:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Phone {get;set;}
    }
}

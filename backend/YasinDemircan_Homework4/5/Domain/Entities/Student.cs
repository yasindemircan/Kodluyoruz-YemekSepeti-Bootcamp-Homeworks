using System;
using Domain.Interface;

namespace Domain.Entities
{
    public class Student: IEntity
    {
        public int Id { get; set; }
        public string Name{get;set;}
        public string LastName { get; set; }
        public int SchoolNumber { get; set; }
        public int Class { get; set; }
    }
}

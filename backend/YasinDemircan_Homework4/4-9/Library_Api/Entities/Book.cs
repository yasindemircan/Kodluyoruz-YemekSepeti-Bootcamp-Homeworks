using System;

namespace Library_Api.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfPage { get; set; }
        public DateTime AddedDate { get; set; }
    }
}

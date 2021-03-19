using System;
using Library_Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library_Api.Contexts
{
    public class LibraryDbContext:DbContext
    {
        public LibraryDbContext(DbContextOptions options) : base(options){
            
        }
        public DbSet<Author> Authors {get;set;}
        public DbSet<Book> Books {get;set;}
    }
}

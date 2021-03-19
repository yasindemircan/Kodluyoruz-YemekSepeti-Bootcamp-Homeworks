using System;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class StudentContext: DbContext
    {
        public StudentContext()
        {
            
        }
        public StudentContext(DbContextOptions options): base(options)
        {
            
        }

        
    }
}

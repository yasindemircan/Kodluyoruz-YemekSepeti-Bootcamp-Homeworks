using Microsoft.EntityFrameworkCore;

namespace week_2.Data
{
     public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
    
        public DbSet<DbModel> DbModels { get; set; }
}
using System;
using Data.EntityConfigurations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Context
{
    public class SchoolContext: DbContext
    {
        public SchoolContext()
        {
            
        }
        public SchoolContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Student> Student {get;set;}
        public DbSet<Teacher> Teacher {get;set;}
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        if(!optionsBuilder.IsConfigured){
           IConfigurationRoot configuration = new ConfigurationBuilder()
                                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                .AddJsonFile("appsettings.json")
                                .Build();
            var connectionString =configuration.GetConnectionString("MssqlDB");
            optionsBuilder.UseSqlServer(connectionString);
        }
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.ApplyConfiguration(new StudentConfiguration());
        modelBuilder.ApplyConfiguration(new TeacherConfiguration());
    }
    
    }


}

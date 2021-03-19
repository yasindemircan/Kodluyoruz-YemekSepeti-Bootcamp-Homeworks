using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfigurations
{
    public class StudentConfiguration: IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder){
            builder.ToTable("Student");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Class).HasMaxLength(2);
            builder.Property(p => p.Id).HasMaxLength(3);
            builder.Property(p => p.SchoolNumber).HasMaxLength(3);
        }
    }
}

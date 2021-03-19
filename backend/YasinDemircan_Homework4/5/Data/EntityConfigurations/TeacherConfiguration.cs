using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfigurations
{
    public class TeacherConfiguration: IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder){
            builder.ToTable("Teacher");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Phone).HasMaxLength(11);
            
        }
    }
}

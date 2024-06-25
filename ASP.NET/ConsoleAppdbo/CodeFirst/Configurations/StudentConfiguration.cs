using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.PersonId).ValueGeneratedNever();
        builder.Property(x => x.SchoolId).ValueGeneratedNever();
        

        builder.HasOne(x => x.person).WithOne(x => x.student).HasForeignKey<Person>(x => x.StudentId);

    }
}
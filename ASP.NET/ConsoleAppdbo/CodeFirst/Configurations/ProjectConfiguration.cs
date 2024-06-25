using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).ValueGeneratedOnAdd();

        builder.Property(b => b.ContactId).ValueGeneratedNever();
        builder.Property(b => b.DeveloperId).ValueGeneratedNever();
        builder.Property(b => b.OptionId).ValueGeneratedNever();

        builder.Property(b => b.Name).IsRequired().HasMaxLength(50);
        builder.Property(b => b.Number).IsRequired().HasMaxLength(50);

        builder.HasOne(b => b.Contact).WithOne(p => p.Project).HasForeignKey<Contact>(p => p.ProjectId);

    }
}
using CodeFirst.Configurations;
using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst;

public class ProjectContext : DbContext 
{
    public ProjectContext() : base() { }

    public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }

    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Developer> Developers { get; set; }
    public DbSet<Option> Options { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<School> Schools { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        modelBuilder.ApplyConfiguration(new ProjectConfiguration());
        modelBuilder.ApplyConfiguration(new DeveloperConfiguration());
        modelBuilder.ApplyConfiguration(new OptionConfiguration());
        modelBuilder.ApplyConfiguration(new ContactConfiguration());
        modelBuilder.ApplyConfiguration(new PersonConfiguration());
        modelBuilder.ApplyConfiguration(new StudentConfiguration());
        modelBuilder.ApplyConfiguration(new SchoolConfiguration());
    }
}
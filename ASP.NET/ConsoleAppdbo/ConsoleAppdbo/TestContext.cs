using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConsoleAppdbo;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Filed> Fileds { get; set; }

    public virtual DbSet<FruitsAndVegetable> FruitsAndVegetables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Filed>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Filed__3214EC076EFA624B");

            entity.ToTable("Filed");

            entity.Property(e => e.FileName).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<FruitsAndVegetable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Fruits_A__3214EC27D398219C");

            entity.ToTable("Fruits_And_Vegetables");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Color).HasMaxLength(70);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Type).HasMaxLength(70);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FoodToOrderAppWPF;

public partial class FoodToOrderWpfPraveenContext : DbContext
{
    public FoodToOrderWpfPraveenContext()
    {
    }

    public FoodToOrderWpfPraveenContext(DbContextOptions<FoodToOrderWpfPraveenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dish> Dishes { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=TJ16AA044-PC,49955;Initial Catalog=FoodToOrder_WPF_Praveen;User=sa;Password=sa@1234;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dish>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Dish");

            entity.Property(e => e.DishName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Restaurant");

            entity.Property(e => e.Rname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RName");
            entity.Property(e => e.Ropen).HasColumnName("ROpen");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("User");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

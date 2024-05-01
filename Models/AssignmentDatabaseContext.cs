using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Assignment_2_NEW.Models;

public partial class AssignmentDatabaseContext : DbContext
{
    public AssignmentDatabaseContext()
    {
    }

    public AssignmentDatabaseContext(DbContextOptions<AssignmentDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Assignment_Database;Integrated Security=True;Connect Timeout=20;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admins__719FE4E8B2DF05F0");

            entity.Property(e => e.AdminId)
                .HasMaxLength(30)
                .HasColumnName("AdminID");
            entity.Property(e => e.AdminDob)
                .HasColumnType("datetime")
                .HasColumnName("AdminDOB");
        });

        //modelBuilder.Entity<Cart>(entity =>
        //{
        //    entity.HasKey(e => e.CartId).HasName("PK__Cart__51BCD797BB05D85D");

        //    entity.ToTable("Cart");

        //    entity.Property(e => e.CartId).HasColumnName("CartID");
        //    entity.Property(e => e.CustomerId)
        //        .HasMaxLength(30)
        //        .HasColumnName("CustomerID");
        //    entity.Property(e => e.OrderCreation).HasColumnType("datetime");
        //    entity.Property(e => e.ProductId)
        //        .HasMaxLength(30)
        //        .HasColumnName("ProductID");

        //    entity.HasOne(d => d.Product).WithMany(p => p.Carts)
        //        .HasForeignKey(d => d.ProductId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("PK_ProductID_Cart_Prod");
        //});

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A2B4DA232A1");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId)
                .HasMaxLength(30)
                .HasColumnName("CategoryID");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B8F92D65FF");

            entity.Property(e => e.CustomerId)
                .HasMaxLength(30)
                .HasColumnName("CustomerID");
            entity.Property(e => e.CustomerDob)
                .HasColumnType("datetime")
                .HasColumnName("CustomerDOB");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6EDEEBB6AAA");

            entity.Property(e => e.ProductId)
                .HasMaxLength(30)
                .HasColumnName("ProductID");
            entity.Property(e => e.CategoryId)
                .HasMaxLength(30)
                .HasColumnName("CategoryID");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_CategoryID_Cat_Prod");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Project6.EnttiyFrameworkCore.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customerinterest> Customerinterests { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Productrating> Productratings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=root;database=project6", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.35-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");

            entity.ToTable("categories");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(255);
        });

        modelBuilder.Entity<Customerinterest>(entity =>
        {
            entity.HasKey(e => e.InterestId).HasName("PRIMARY");

            entity.ToTable("customerinterests");

            entity.HasIndex(e => e.CustomerId, "CustomerID");

            entity.HasIndex(e => e.ProductId, "ProductID");

            entity.Property(e => e.InterestId)
                .ValueGeneratedNever()
                .HasColumnName("InterestID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Customerinterests)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("customerinterests_ibfk_2");

            entity.HasOne(d => d.Product).WithMany(p => p.Customerinterests)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("customerinterests_ibfk_1");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRIMARY");

            entity.ToTable("products");

            entity.HasIndex(e => e.CategoryId, "CategoryID");

            entity.HasIndex(e => e.VendorId, "VendorID");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("ProductID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("ImageURL");
            entity.Property(e => e.Price).HasPrecision(10, 2);
            entity.Property(e => e.ProductName).HasMaxLength(255);
            entity.Property(e => e.VendorId).HasColumnName("VendorID");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("products_ibfk_1");

            entity.HasOne(d => d.Vendor).WithMany(p => p.Products)
                .HasForeignKey(d => d.VendorId)
                .HasConstraintName("products_ibfk_2");
        });

        modelBuilder.Entity<Productrating>(entity =>
        {
            entity.HasKey(e => e.RatingId).HasName("PRIMARY");

            entity.ToTable("productratings");

            entity.HasIndex(e => e.CustomerId, "CustomerID");

            entity.HasIndex(e => e.ProductId, "ProductID");

            entity.Property(e => e.RatingId)
                .ValueGeneratedNever()
                .HasColumnName("RatingID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Productratings)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("productratings_ibfk_2");

            entity.HasOne(d => d.Product).WithMany(p => p.Productratings)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("productratings_ibfk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("users");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Role).HasColumnType("enum('Retailer','Customer','Admin')");
            entity.Property(e => e.Username).HasMaxLength(255);
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.VendorId).HasName("PRIMARY");

            entity.ToTable("vendors");

            entity.Property(e => e.VendorId)
                .ValueGeneratedNever()
                .HasColumnName("VendorID");
            entity.Property(e => e.ContactDetails).HasMaxLength(255);
            entity.Property(e => e.VendorName).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

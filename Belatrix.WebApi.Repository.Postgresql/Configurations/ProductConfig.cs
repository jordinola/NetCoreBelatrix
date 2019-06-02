using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.WebApi.Repository.Postgresql.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn();

            builder.Property(p => p.ProductName)
                .HasColumnName("product_name")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.SupplierId)
                .HasColumnName("supplier_id")
                .IsRequired();

            builder.Property(p => p.UnitPrice)
                .HasColumnName("unit_price")
                .HasColumnType("decimal(12,2)")
                .IsRequired();

            builder.Property(p => p.Package)
                .HasColumnName("package")
                .HasMaxLength(30);

            builder.Property(p => p.IsDiscontinued)
                .HasColumnName("is_discontinued")
                .IsRequired();

            builder.HasIndex(e => e.SupplierId)
                .HasName("product_supplier_id_idx");

            builder.HasIndex(e => e.ProductName)
                .HasName("product_product_name_idx");

            builder.HasOne(p => p.Supplier)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.SupplierId)
                .IsRequired()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

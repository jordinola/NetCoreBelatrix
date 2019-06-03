using Belatrix.WebApi.Models;
using Belatrix.WebApi.Repository.PostgresSQL.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.WebApi.Repository.PostgresSQL.Configurations
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
                .HasColumnName("ProductName".ToLowerWithUnderdash())
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.SupplierId)
                .HasColumnName("SupplierId".ToLowerWithUnderdash())
                .IsRequired();

            builder.Property(p => p.UnitPrice)
                .HasColumnName("UnitPrice".ToLowerWithUnderdash())
                .HasColumnType($"decimal({12},{2})")
                .IsRequired();

            builder.Property(p => p.Package)
                .HasColumnName("Package".ToLowerWithUnderdash())
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(p => p.IsDiscontinued)
                .HasColumnName("IsDiscontinued".ToLowerWithUnderdash())
                .IsRequired();

            builder.HasIndex(e => new { e.SupplierId })
                .HasName("product_supplier_id_idx");

            builder.HasIndex(e => new { e.ProductName })
                .HasName("product_product_name_idx");

            builder.HasOne(p => p.Supplier)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.SupplierId)
                .IsRequired()
                .HasConstraintName("product_supplier_id_fkey");

        }
    }
}

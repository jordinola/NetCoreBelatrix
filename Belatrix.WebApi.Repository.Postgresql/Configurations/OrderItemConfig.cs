using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.WebApi.Repository.Postgresql.Configurations
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("order_item")
                .HasKey(p => p.Id)
                .HasName("order_item_id_key");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn();

            builder.Property(p => p.OrderId)
                .HasColumnName("order_id")
                .IsRequired();

            builder.Property(p => p.ProductId)
                .HasColumnName("product_id")
                .IsRequired();

            builder.Property(p => p.UnitPrice)
                .HasColumnName("unit_price")
                .HasColumnType("decimal(12,2)")
                .IsRequired();

            builder.Property(p => p.Quantity)
                .HasColumnName("quantity")
                .IsRequired();

            builder.HasIndex(e => e.OrderId)
                .HasName("order_item_order_id_idx");

            builder.HasIndex(e => e.ProductId)
                .HasName("order_item_product_id_idx");

            builder.HasOne(p => p.Order)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(p => p.OrderId)
                .HasConstraintName("order_item_order_id_fkey")
                .IsRequired()
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(p => p.ProductId)
                .HasConstraintName("order_item_product_id_fkey")
                .IsRequired()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

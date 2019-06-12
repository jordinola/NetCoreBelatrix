using Belatrix.WebApi.Models;
using Belatrix.WebApi.Repository.PostgresSQL.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.WebApi.Repository.PostgresSQL.Configurations
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("order_item");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn();

            builder.Property(p => p.OrderId)
                .HasColumnName("OrderId".ToLowerWithUnderdash())
                .IsRequired();

            builder.Property(p => p.ProductId)
                .HasColumnName("ProductId".ToLowerWithUnderdash())
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(p => p.UnitPrice)
                .HasColumnName("UnitPrice".ToLowerWithUnderdash())
                .HasColumnType($"decimal({12},{2})")
                .IsRequired();

            builder.Property(p => p.Quantity)
                .HasColumnName("Quantity".ToLowerWithUnderdash())
                .IsRequired();

            builder.HasIndex(e => new { e.OrderId })
                .HasName("order_item_order_id_idx");

            builder.HasIndex(e => new { e.ProductId })
                .HasName("order_item_product_idx");

            builder.HasOne(p => p.Order)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(p => p.OrderId)
                .IsRequired()
                .HasConstraintName("order_item_order_id_fkey");

            builder.HasOne(p => p.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(p => p.ProductId)
                .IsRequired()
                .HasConstraintName("order_item_product_id_fkey");
        }
    }
}

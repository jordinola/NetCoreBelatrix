using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.WebApi.Repository.Postgresql.Configurations
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("order")
                .HasKey(p => p.Id)
                .HasName("order_id_key");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn();

            builder.Property(p => p.OrderDate)
                .HasColumnName("order_date")
                .IsRequired();

            builder.Property(p => p.OrderNumber)
                .HasColumnName("order_number")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(p => p.CustomerId)
                .HasColumnName("customer_id")
                .IsRequired();

            builder.Property(p => p.TotalAmount)
                .HasColumnName("total_amount")
                .HasColumnType("decimal(12,2)")
                .IsRequired();

            builder.HasIndex(e => e.CustomerId)
                .HasName("order_customer_id_idx");

            builder.HasIndex(e => e.OrderDate)
                .HasName("order_order_date_idx");

            builder.HasOne(p => p.Customer)
                .WithMany(p => p.Orders)
                .HasForeignKey(p => p.CustomerId)
                .HasConstraintName("order_customer_id_fkey")
                .IsRequired()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

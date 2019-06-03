using Belatrix.WebApi.Models;
using Belatrix.WebApi.Repository.PostgresSQL.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.WebApi.Repository.PostgresSQL.Configurations
{

    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("supplier");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn();

            builder.Property(p => p.OrderDate)
                .HasColumnName("OrderDate".ToLowerWithUnderdash())
                .IsRequired();

            builder.Property(p => p.OrderNumber)
                .HasColumnName("OrderNumber".ToLowerWithUnderdash())
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(p => p.CustomerId)
                .HasColumnName("CustomerId".ToLowerWithUnderdash())
                .IsRequired();

            builder.Property(p => p.TotalAmount)
                .HasColumnName("City".ToLowerWithUnderdash())
                .HasColumnType($"decimal({12},{2})")
                .IsRequired();

            builder.HasIndex(e => new { e.CustomerId })
                .HasName("order_customer_id_idx");

            builder.HasIndex(e => new { e.OrderDate })
                .HasName("order_order_date_idx");
        }
    }
}

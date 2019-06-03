using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.WebApi.Repository.Postgresql.Configurations
{
    public class SupplierConfig : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("supplier")
                .HasKey(p => p.Id)
                .HasName("supplier_id_key");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn();

            builder.Property(p => p.CompanyName)
                .HasColumnName("company_name")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(p => p.ContactName)
                .HasColumnName("contact_name")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.ContactTitle)
                .HasColumnName("contact_title")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(p => p.City)
                .HasColumnName("city")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(p => p.Country)
                .HasColumnName("country")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(p => p.Phone)
                .HasColumnName("phone")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(p => p.Fax)
                .HasColumnName("fax")
                .HasMaxLength(30)
                .IsRequired();

            builder.HasIndex(e => e.CompanyName)
                .HasName("supplier_company_name_idx");

            builder.HasIndex(e => e.Country)
                .HasName("supplier_country_idx");
        }
    }
}

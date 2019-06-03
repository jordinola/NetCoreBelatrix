using Belatrix.WebApi.Models;
using Belatrix.WebApi.Repository.PostgresSQL.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.WebApi.Repository.PostgresSQL.Configurations
{
    public class SupplierConfig : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("supplier");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .UseNpgsqlIdentityColumn();

            builder.Property(p => p.CompanyName)
                .HasColumnName("CompanyName".ToLowerWithUnderdash())
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(p => p.ContactName)
                .HasColumnName("ContactName".ToLowerWithUnderdash())
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.ContactTitle)
                .HasColumnName("ContactTitle".ToLowerWithUnderdash())
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(p => p.City)
                .HasColumnName("City".ToLowerWithUnderdash())
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(p => p.Country)
                .HasColumnName("Country".ToLowerWithUnderdash())
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(p => p.Phone)
                .HasColumnName("Phone".ToLowerWithUnderdash())
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(p => p.Fax)
                .HasColumnName("Fax".ToLowerWithUnderdash())
                .HasMaxLength(30)
                .IsRequired();

            builder.HasIndex(e => new { e.CompanyName })
                .HasName("supplier_name_idx");

            builder.HasIndex(e => new { e.Country })
                .HasName("supplier_country_idx");
        }
    }
}

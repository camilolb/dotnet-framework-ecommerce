using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaTecnica.Core.Entities;

namespace Pruebatecnica.Infraestructura.Data.Configuration
{
    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> entity)
        {
            entity.ToTable("Owner");

            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.Property(e => e.Adress)
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.Property(e => e.Phone)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.Property(e => e.Create).HasColumnType("datetime");
            entity.Property(e => e.Modify).HasColumnType("datetime");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaTecnica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace Pruebatecnica.Infraestructura.Data.Configuration
{
    public class BuildConfiguration : IEntityTypeConfiguration<Build>
    {
        public void Configure(EntityTypeBuilder<Build> entity)
        {
                entity.ToTable("Build");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Create).HasColumnType("datetime");

                entity.Property(e => e.Modify).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Tower)
                    .HasMaxLength(10)
                    .IsUnicode(false);
        }
    }
}

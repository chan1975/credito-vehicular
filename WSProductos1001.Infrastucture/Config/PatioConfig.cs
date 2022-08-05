﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSProductos1001.Entities;

namespace WSProductos1001.Infrastucture.Config;

public class PatioConfig: IEntityTypeConfiguration<EPatio>
{
    public void Configure(EntityTypeBuilder<EPatio> builder)
    {
        builder.ToTable("patio");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("id");
        builder.Property(p =>p.Name).IsRequired().HasColumnName("nombre").HasMaxLength(128);
        builder.Property(p =>p.Address).IsRequired().HasColumnName("direccion").HasMaxLength(256);
        builder.Property(p =>p.Phone).IsRequired().HasColumnName("telefono").HasMaxLength(16);
        builder.Property(p => p.NumberSalePoint).IsRequired().HasColumnName("numero_punto_venta");

    }
}
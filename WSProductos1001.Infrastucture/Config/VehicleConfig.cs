using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSProductos1001.Entities;

namespace WSProductos1001.Infrastucture.Config
{
    internal class VehicleConfig : IEntityTypeConfiguration<EVehicle>
    {
        public void Configure(EntityTypeBuilder<EVehicle> builder)
        {
            builder.ToTable("vehiculo");
            builder.HasKey(v => v.Id);
            builder.Property(v => v.Id).HasColumnName("id");
            builder.Property(v => v.Appraisal).HasColumnName("avaluo").IsRequired();
            builder.Property(v => v.CylinderCapacity).HasColumnName("cilindraje").IsRequired();
            builder.Property(v => v.Year).HasColumnName("anio").IsRequired();
            builder.Property(v => v.BrandId).HasColumnName("marca_id").IsRequired();
            builder.Property(v => v.ChassisNumber).HasColumnName("numero_chasis").IsRequired();
            builder.Property(v => v.LicensePlate).HasColumnName("placa").IsRequired();
            builder.Property(v => v.Model).HasColumnName("modelo").IsRequired();
            builder.Property(v => v.TypeId).HasColumnName("tipo_id").IsRequired(false);
            
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSProductos1001.Entities;

namespace WSProductos1001.Infrastucture.Config;

public class RequestCreditConfig : IEntityTypeConfiguration<ERequestCredit>
{
    public void Configure(EntityTypeBuilder<ERequestCredit> builder)
    {
        builder.ToTable("solicitudes_credito");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("id");
        builder.Property(p => p.BuildDate).HasColumnName("fecha_elaboracion");
        builder.Property(p => p.ClientId).HasColumnName("id_cliente");
        builder.Property(p => p.PatioId).HasColumnName("id_patio");
        builder.Property(p => p.VehicleId).HasColumnName("id_vehiculo");
        builder.Property(p => p.TermMonth).HasColumnName("plazo_meses");
        builder.Property(p => p.Fee).HasColumnName("cuota_mensual");
        builder.Property(p => p.Entry).HasColumnName("entrada");
        builder.Property(p => p.AgentId).HasColumnName("id_agente");
        builder.Property(p => p.Observation).HasColumnName("observacion");
        builder.Property(p => p.CreditStatus).HasColumnName("stado_credito");
        
    }
}
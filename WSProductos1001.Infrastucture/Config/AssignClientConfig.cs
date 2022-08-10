using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSProductos1001.Entities;

namespace WSProductos1001.Infrastucture.Config;

public class AssignClientConfig : IEntityTypeConfiguration<EAssignClient>
{
    public void Configure(EntityTypeBuilder<EAssignClient> builder)
    {
        builder.ToTable("asignacion_cliente_patio");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).HasColumnName("id");
        builder.Property(a => a.ClientId).HasColumnName("id_cliente");
        builder.Property(a => a.PatioId).HasColumnName("id_patio");
        builder.Property(a => a.AssignDate).HasColumnName("fecha_asignacion");
    }
}
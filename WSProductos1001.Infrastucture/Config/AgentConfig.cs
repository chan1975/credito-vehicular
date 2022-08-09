using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSProductos1001.Entities;

namespace WSProductos1001.Infrastucture.Config;

public class AgentConfig: IEntityTypeConfiguration<EAgent>
{
    public void Configure(EntityTypeBuilder<EAgent> builder)
    {
        builder.ToTable("agente");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).HasColumnName("id");
        builder.Property(a => a.Names).HasColumnName("nombres");
        builder.Property(a => a.LastNames).HasColumnName("apellidos");
        builder.Property(a => a.Address).HasColumnName("direccion");
        builder.Property(a => a.Phone).HasColumnName("telefono");
        builder.Property(a => a.CellPhone).HasColumnName("celular");
        builder.Property(a => a.PatioId).HasColumnName("patio_id");
        builder.Property(a => a.Age).HasColumnName("edad");
    }
}
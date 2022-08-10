using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSProductos1001.Entities;

namespace WSProductos1001.Infrastucture.Config;

public class ClientConfig: IEntityTypeConfiguration<EClient>
{
    public void Configure(EntityTypeBuilder<EClient> builder)
    {
        builder.ToTable("cliente");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).HasColumnName("id");
        builder.Property(a => a.Names).HasColumnName("nombres");
        builder.Property(a => a.LastNames).HasColumnName("apellidos");
        builder.Property(a => a.Address).HasColumnName("direccion");
        builder.Property(a => a.Phone).HasColumnName("telefono");
        builder.Property(a => a.Identification).HasColumnName("identificacion");
        builder.Property(a => a.BirthDay).HasColumnName("fecha_nacimiento");
        builder.Property(a => a.MaritalStatus).HasColumnName("estado_civil");
        builder.Property(a => a.SpouseIdentification).HasColumnName("identificacion_conyuge");
        builder.Property(a => a.SpouseName).HasColumnName("nombre_conyuge");
        builder.Property(a => a.SubjectCredit).HasColumnName("sujeto_credito");
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSProductos1001.Entities;
using WSProductos1001.Entities.Catalogs;

namespace WSProductos1001.Infrastucture.Config
{
    public class SubjectCreditConfig : IEntityTypeConfiguration<SubjectCredit>
    {
        public void Configure(EntityTypeBuilder<SubjectCredit> builder)
        {
            builder.ToTable("catalogo_sujetos_credito");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Description).HasColumnName("descripcion").IsRequired();
        }
    }
}

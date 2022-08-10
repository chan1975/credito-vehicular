using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSProductos1001.Entities;

namespace WSProductos1001.Infrastucture.Config
{
    public class BrandConfig : IEntityTypeConfiguration<EBrand>
    {
        public void Configure(EntityTypeBuilder<EBrand> builder)
        {
            builder.ToTable("marca");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Name).HasColumnName("nombre").IsRequired();
        }
    }
}

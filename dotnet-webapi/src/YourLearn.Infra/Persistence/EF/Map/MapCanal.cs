using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YouLearn.Domain.Entities;

namespace YouLearn.Infra.Persistence.EF.Map
{
    public class MapCanal : IEntityTypeConfiguration<Canal>
    {
        public void Configure(EntityTypeBuilder<Canal> builder)
        {
            builder.ToTable("Canal");

            //key
            builder.HasKey(x => x.Id);

            //foreignkey
            builder.HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey("IdUsuario");

            //properties
            builder.Property(x => x.Nome)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.UrlLogo)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}

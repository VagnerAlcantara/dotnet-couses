using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YouLearn.Domain.Entities;

namespace YouLearn.Infra.Persistence.EF.Map
{
    public class MapPlayList : IEntityTypeConfiguration<PlayList>
    {
        public void Configure(EntityTypeBuilder<PlayList> builder)
        {
            //nome da table
            builder.ToTable("PlayList");
            //primary key
            builder.HasKey(x => x.Id);
            //foreigkey
            builder.HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey("IdUsuario");

            //properties
            builder.Property(x => x.Nome)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}

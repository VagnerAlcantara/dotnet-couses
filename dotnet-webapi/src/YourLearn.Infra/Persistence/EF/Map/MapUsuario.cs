using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YouLearn.Domain.Entities;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Infra.Persistence.EF.Map
{
    public class MapUsuario : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            //Nome da tabela
            builder.ToTable("Usuario");

            //Chave primária
            builder.HasKey(x => x.Id);

            //Mapeando value objects
            builder.OwnsOne<Nome>(x => x.Nome, nm =>
            {
                nm.Property(x => x.PrimeiroNome)
                .HasMaxLength(50)
                .HasColumnName("PrimeiroNome")
                .IsRequired();

                nm.Property(x => x.UltimoNome)
                .HasMaxLength(50)
                .HasColumnName("UltimoNome")
                .IsRequired();
            });

            builder.OwnsOne<Email>(x => x.Email, nm =>
            {
                nm.Property(x => x.Endereco)
                .HasMaxLength(200)
                .HasColumnName("Email")
                .IsRequired();
            });

            builder.OwnsOne<Senha>(x => x.Senha, nm =>
            {
                nm.Property(x => x.Valor)
                .HasMaxLength(36)
                .HasColumnName("Senha")
                .IsRequired();
            });
        }
    }
}

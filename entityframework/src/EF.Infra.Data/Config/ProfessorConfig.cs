using EF.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EF.Infra.Data.Config
{
    public class ProfessorConfig : EntityTypeConfiguration<Professor>
    {
        public ProfessorConfig()
        {
            ToTable("Professor");

            HasKey(p => p.ProfessorId);

            Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}

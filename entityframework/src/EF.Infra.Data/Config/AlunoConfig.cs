using EF.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EF.Infra.Data.Config
{
    public class AlunoConfig: EntityTypeConfiguration<Aluno>
    {
        public AlunoConfig()
        {
            ToTable("Aluno");

            HasKey(a => a.AlunoId);

            HasRequired(a => a.Turma)
                .WithMany(a => a.Alunos)
                .Map(a => a.MapKey("TurmaId"));


        }
    }
}

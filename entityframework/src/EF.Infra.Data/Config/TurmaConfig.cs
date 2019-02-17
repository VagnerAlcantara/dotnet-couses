using EF.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EF.Infra.Data.Config
{
    public class TurmaConfig : EntityTypeConfiguration<Turma>
    {
        public TurmaConfig()
        {
            ToTable("Turma");

            HasKey(t => t.TurmaId);

            Property(t => t.DataInicio)
                .IsRequired();

            Property(t => t.DataFim)
                .IsRequired();

            //Na entidade Turma, a propriedade do tipo Curso é obrigatória
            HasRequired(x => x.Curso)
               .WithMany() //Curso pode ter muitas turmas
               .Map(m => m.MapKey("CursoId"));//a chave estrangeira em Turma é CursoId

            //Novamente, em Turma a propriedade do tipo Professor é requerida
            HasRequired(x => x.Professor)
               .WithMany(x => x.Turmas) //a classe Professor pode ter uma lista de Turma
               .Map(m => m.MapKey("ProfessorId"));//a chave estrangeira é ProfessorId
            

        }
    }
}

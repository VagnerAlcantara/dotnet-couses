using EF.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EF.Infra.Data.Config
{
    public class CursoConfig : EntityTypeConfiguration<Curso>
    {
        public CursoConfig()
        {
            ToTable("Curso");

            HasKey(c => c.CursoId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            /*Curso tem uma lista de Professores*/
            HasMany(x => x.Professores)
              .WithMany(x => x.Cursos) //...e professores uma lista de Cursos
              .Map(m => //esse relacionamento será mapeado em uma terceira tabela
               {
                   m.MapLeftKey("CursoId"); //chave da esquerda será de CursoId
                   m.MapRightKey("ProfessorId"); //Chave da direita será ProfessorId
                   m.ToTable("CursoProfessor");// e o nome da tabela será CursoProfessor
               });
        }
    }
}
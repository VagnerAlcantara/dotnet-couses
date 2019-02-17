using System.Collections.Generic;

namespace EF.Domain.Entities
{
    public class Professor
    {
        public Professor(string nome, ICollection<Turma> turmas, ICollection<Curso> cursos)
        {
            this.Nome = nome;
            this.Turmas = turmas;
            this.Cursos = cursos;
        }

        public int ProfessorId { get; private set; }
        public string Nome { get; private set; }
        public virtual ICollection<Turma> Turmas { get; private set; }
        public virtual ICollection<Curso> Cursos { get; private set; }
    }
}

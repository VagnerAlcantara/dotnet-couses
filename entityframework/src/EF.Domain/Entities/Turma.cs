using System;
using System.Collections.Generic;

namespace EF.Domain.Entities
{
    public class Turma
    {
        public Turma(DateTime dataInicio, DateTime dataFim, Professor professor, Curso curso, ICollection<Aluno> alunos)
        {
            this.DataInicio = dataInicio;
            this.DataFim = dataFim;
            this.Professor = professor;
            this.Curso = curso;
            this.Alunos = alunos;
        }

        public int TurmaId { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public virtual Professor Professor { get; private set; }
        public virtual Curso Curso { get; private set; }
        public ICollection<Aluno> Alunos { get; private set; }

    }
}

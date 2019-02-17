using System.Collections.Generic;

namespace EF.Domain.Entities
{
    public class Curso
    {
        public Curso(string nome)
        {
            Professores = new List<Professor>();
            this.Nome = nome;
        }
        public int CursoId { get; private set; }
        public string Nome { get; private set; }
        public virtual ICollection<Professor> Professores { get; set; }
    }
}

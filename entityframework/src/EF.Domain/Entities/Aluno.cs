namespace EF.Domain.Entities
{ 

    public class Aluno
    {
        public Aluno(string nome, int matricula, Turma turma)
        {
            this.Nome = nome;
            this.Matricula = matricula;
            this.Turma = turma;
        }

        public int AlunoId { get; private set; }
        public string Nome { get; private set; }
        public int Matricula { get; private set; }
        public virtual Turma Turma { get; private set; }
    }
}

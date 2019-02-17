using System;

namespace Locadora.Domain.Entities
{
    public abstract class Pessoa
    {
        public int Id { get; private set; }
        public string Cpf { get; private set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }

        public Pessoa(string cpf, string nome, DateTime dataNascimento, string telefone, string email)
        {
            this.IsValid(nome);
            this.Cpf = cpf;
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
            this.Telefone = telefone;
            this.Email = email;

        }

        private void IsValid(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new Exception("O nome é de preenchimento obrigatório");

        }
    }
}

using System;

namespace Locadora.Domain.Entities
{
    public class Usuario : Pessoa
    {
        public string Senha { get; private set; }
        public bool Ativo { get; private set; }
        public int IdPessoa { get; private set; }

        public Usuario(string senha, bool ativo, int idPessoa, string cpf, string nome, DateTime dataNascimento, string telefone, string email) 
            : base(cpf, nome, dataNascimento, telefone, email)
        {
            this.Senha = senha;
            this.Ativo = ativo;
            this.IdPessoa = IdPessoa;
        }

        
        
    }
}

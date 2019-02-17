using System;

namespace Locadora.Domain.Entities
{
    public class Cliente : Pessoa
    {
        public int Id { get; private set; }
        public int Matricula { get; private set; }
        public bool Ativo { get; private set; }
        public int? IdPessoa { get; set; }

        
        public Cliente(int? id, int matricula, bool ativo, string cpf, int? idPessoa, string nome, DateTime dataNascimento, string telefone, string email) 
            : base(cpf, nome, dataNascimento, telefone, email)
        {
            if (id.HasValue)
                this.Id = id.Value;

            this.Matricula = matricula;
            this.Ativo = ativo;
            this.IdPessoa = idPessoa;
        }

        public void Inativar()
        {
            this.Ativo = false;
        }

        public void Ativar()
        {
            this.Ativo = true;
        }
    }
}

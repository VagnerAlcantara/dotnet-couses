using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Locadora.Domain.Entities
{
    public class Endereco
    {
        public int EnderecoId { get; private set; }
        public int Cep { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public int IdPessoa { get; private set; }
        

        public Endereco(int cep, string numero, string complemento)
        {
            this.IsValid(cep, numero, complemento);
            this.Cep = cep;
            this.Numero = numero;
            this.Complemento = complemento;
        }

        private void IsValid(int cep, string numero, string complemento)
        {

        }
    }
}

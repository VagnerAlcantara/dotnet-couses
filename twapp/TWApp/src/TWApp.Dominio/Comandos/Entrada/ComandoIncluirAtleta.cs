using System;
using TWApp.Compartilhado.Comandos;

namespace TWApp.Dominio.Comandos.Entrada
{
    public class ComandoIncluirAtleta : IComando
    {
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

    }
}

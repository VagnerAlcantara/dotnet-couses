using System;

namespace YouLearn.Domain.Arguments.Usuario
{
    public class AutenticarUsuarioResponse
    {
        public AutenticarUsuarioResponse(Guid id, string primeiroNome)
        {
            Id = id;
            PrimeiroNome = primeiroNome;
        }

        public Guid Id { get; private set; }
        public string PrimeiroNome { get; private set; }

        public static explicit operator AutenticarUsuarioResponse(Entities.Usuario usuario)
        {
            return new AutenticarUsuarioResponse(usuario.Id, usuario.Nome.PrimeiroNome);
        }
    }
}

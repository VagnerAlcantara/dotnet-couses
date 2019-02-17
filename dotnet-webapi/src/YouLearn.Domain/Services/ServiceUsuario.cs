using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Resources;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Domain.Services
{
    public class ServiceUsuario : Notifiable, IServiceUsuario
    {
        private readonly IRepositoryUsuario _repositoryUsuario;

        public ServiceUsuario(IRepositoryUsuario repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }

        public AdicionarUsuarioResponse AdicionarUsuario(AdicionarUsuarioRequest request)
        {
            if (request == null)
            {
                AddNotification("AdicionarUsuarioRequest", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("AdicionarUsuarioRequest"));
                return null;
            }

            Nome nome = new Nome(request.PrimeiroNome, request.SegundoNome);
            Email email = new Email(request.Email);
            Senha senha = new Senha(request.Senha);
            Usuario usuario = new Usuario(nome, email, senha);

            AddNotifications(usuario);


            if (IsInvalid())
                return null;

            _repositoryUsuario.Salvar(usuario);

            return new AdicionarUsuarioResponse(usuario.Id);
        }

        public AutenticarUsuarioResponse AutenticarUsuario(AutenticarUsuarioRequest request)
        {
            if (request == null)
            {
                AddNotification("AutentiticarUsuarioRequest", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("AutentiticarUsuarioRequest"));
                return null;
            }

            Email email = new Email(request.Email);
            Senha senha = new Senha(request.Senha);
            Usuario usuario = new Usuario(email, senha);

            AddNotifications(usuario);

            if (IsInvalid())
            {
                return null;
            }

            usuario = _repositoryUsuario.Obter(usuario.Email.Endereco, usuario.Senha.Valor);

            if (usuario == null)
            {
                AddNotification("Usuário", MSG.DADOS_NAO_ENCONTRADOS);
                return null;
            }
            //conversão explicita: (AutentiticarUsuarioResponse)usuario;

            return (AutenticarUsuarioResponse)usuario;
        }
    }
}

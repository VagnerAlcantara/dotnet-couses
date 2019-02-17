using System;
using TWApp.Compartilhado.Comandos;
using TWApp.Compartilhado.Entidades;
using TWApp.Dominio.Comandos.Entrada;
using TWApp.Dominio.Comandos.Saida;
using TWApp.Dominio.Entidades;
using TWApp.Dominio.Interfaces.Repositorio;
using TWApp.Dominio.ObjetosDeValor;

namespace TWApp.Dominio.Comandos.Manipuladores
{
    public class ComandoManipulacaoAtleta :
        Notificacao,
        IManipuladorComando<ComandoIncluirAtleta>
    {
        private readonly IRepositorioAtleta _repositorioAtleta;

        public ComandoManipulacaoAtleta(IRepositorioAtleta repositorioAtleta)
        {
            _repositorioAtleta = repositorioAtleta;
        }

        public IResultadoComando Manipular(ComandoIncluirAtleta comando)
        {
            //Passo 1. Verifica se cpf existe
            if (_repositorioAtleta.ExisteCpf(comando.Cpf))
                AdicionarNotificacao("Cpf", "Cpf já cadastrado");

            //Passo 2. Criar um atleta
            Nome nome = new Nome(comando.PrimeiroNome, comando.Sobrenome);
            Cpf cpf = new Cpf(comando.Cpf);
            Senha senha = new Senha(comando.Senha);
            Usuario usuario = new Usuario(comando.Login, senha);
            Atleta atleta = new Atleta(nome, comando.DataNascimento, cpf, usuario);

            //Passo 3. Adicionar notificações
            AdicionarNotificacao(nome.Notificacoes);
            AdicionarNotificacao(cpf.Notificacoes);
            AdicionarNotificacao(senha.Notificacoes);
            AdicionarNotificacao(usuario.Notificacoes);
            AdicionarNotificacao(atleta.Notificacoes);

            //Passo 4. Verifica se é válido
            if (!EValido())
                return null;

            //Passo 5. Grava no banco
            _repositorioAtleta.Salvar(atleta);

            return new ComandoResultadoInclusaoAtleta(atleta.Nome.ToString());
        }
    }
}

using System;
using System.Collections.Generic;

namespace TWApp.Compartilhado.Entidades
{
    public class Notificacao
    {
        public string Propriedade { get; private set; }
        public string Mensagem { get; private set; }
        public ICollection<Notificacao> Notificacoes { get; private set; }
        public Notificacao()
        {
            Notificacoes = new List<Notificacao>();
        }

        private Notificacao(string propriedade, string mensagem)
        {
            Propriedade = propriedade;
            Mensagem = mensagem;

            if (string.IsNullOrEmpty(Propriedade))
                throw new Exception("Propriedade é obrigatória");

            if (string.IsNullOrEmpty(Mensagem))
                throw new Exception("Mensagem é obrigatória");

        }

        public void AdicionarNotificacao(Notificacao notificacao)
        {
            Notificacoes.Add(notificacao);
        }

        public void AdicionarNotificacao(ICollection<Notificacao> notificacoes)
        {
            Notificacoes = notificacoes;
        }

        public void AdicionarNotificacao(string propriedade, string mensagem)
        {
            Notificacoes.Add(new Notificacao(propriedade, mensagem));
        }

        public IEnumerable<Notificacao> ObterNotificacao()
        {
            return Notificacoes;
        }

        public bool EValido() => Notificacoes.Count == 0;
    }
}

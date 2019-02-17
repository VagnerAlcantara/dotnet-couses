using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using YouLearn.Domain.Base;
using YouLearn.Domain.Resources;

namespace YouLearn.Domain.Entities
{
    public class Canal : EntityBase
    {
        protected Canal()
        {

        }
        public Canal(string nome, string urlLogo, Usuario usuario)
        {
            Nome = nome;
            UrlLogo = urlLogo;
            Usuario = usuario;

            new AddNotifications<Canal>(this)
                .IfNullOrInvalidLength(x => x.Nome, 2, 50, MSG.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Nome canal", 1, 50))
                .IfNullOrInvalidLength(x => x.UrlLogo, 4, 200, MSG.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Url logo canal", 1, 50));

            AddNotifications(usuario);

        }

        public string Nome { get; private set; }
        public string UrlLogo { get; private set; }
        public Usuario Usuario { get; private set; }
    }
}

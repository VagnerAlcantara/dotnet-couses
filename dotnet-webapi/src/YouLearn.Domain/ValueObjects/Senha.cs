using prmToolkit.NotificationPattern;
using YouLearn.Domain.Extensions;
namespace YouLearn.Domain.ValueObjects
{
    public class Senha : Notifiable
    {
        public Senha(string valor)
        {
            Valor = valor;

            new AddNotifications<Senha>(this).IfNullOrInvalidLength(x => x.Valor, 3, 32);

            Valor = valor.ConvertToMD5();
        }

        

        public string Valor { get; private set; }
    }
}

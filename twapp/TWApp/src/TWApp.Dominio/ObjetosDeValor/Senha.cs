using System.Text;
using TWApp.Compartilhado.Entidades;

namespace TWApp.Dominio.ObjetosDeValor
{
    public class Senha : ObjetoDeValor
    {
        private string SenhaValor;

        public Senha(string senha)
        {
            SenhaValor = senha;

            if (string.IsNullOrEmpty(SenhaValor))
                AdicionarNotificacao("Senha", "Senha é obrigatória");

        }
        public string Valor
        {
            get { return Encrypt(SenhaValor); }
        }

        private string Encrypt(string password)
        {
            if (!string.IsNullOrEmpty(password))
                return "";

            var pass = string.Empty;

            pass = (pass += "|2d331cca-f6c0-40c0-bb43-6e32989c2881"); //Trocar hash
            var mD5 = System.Security.Cryptography.MD5.Create(pass);
            var data = mD5.ComputeHash(Encoding.Default.GetBytes(pass));
            var sbString = new StringBuilder();

            foreach (var item in data)
                sbString.Append(item.ToString("x2"));

            return sbString.ToString();
        }
    }
}

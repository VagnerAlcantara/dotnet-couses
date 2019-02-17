using System;
using System.Text.RegularExpressions;

namespace GerenciadorUsuarioService.Dominio.Validacao
{
    public static class Email
    {
        static readonly Regex ValidEmailRegex = CreateValidEmailRegex();

        private static Regex CreateValidEmailRegex()
        {
            const string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                                             + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                                             + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
        }

        public static bool EmailIsValid(string email)
        {
            try
            {
                return ValidEmailRegex.IsMatch(email);
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}

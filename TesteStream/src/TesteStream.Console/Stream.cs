using System;
using System.Text.RegularExpressions;

namespace TesteStream.Console
{
    public class Stream : IStream
    {
        private string _input;
        private int _lastIndexRead = 0;

        public Stream(string input) => _input = input;


        public char? FirstChar()
        {
            bool consonantFound = false;
            char? vogal = null;

            while (HasNext())
            {
                //obtendo o character
                char next = GetNext();

                //encontrado primeira consoante
                if (IsConsonant(next) && !consonantFound)
                    consonantFound = true;

                //enquanto não encontrar uma consoante, continua percorrendo a string
                if (!consonantFound)
                    continue;

                //verifica se é vogal
                if (IsVogal(next))
                {
                    //verifica se vogal já foi armazenada, caso já tenha sido, limpamos pois se trata de repetição de vogal
                    if (vogal.HasValue && vogal.Value.ToString().ToLower() == next.ToString().ToLower())
                        vogal = null;
                    else
                        vogal = next;
                }
            }
            return vogal;
        }

        /// <summary>
        /// Verifica se o char é uma vogal
        /// </summary>
        /// <param name="input">char analisado</param>
        /// <returns>retorna se é vogal</returns>
        public static bool IsVogal(char input)
        {
            return Regex.Match(input.ToString(), "^([aeiouAEIOU]+)$").Success;
        }
        /// <summary>
        /// Verifica se o char é uma consoante
        /// </summary>
        /// <param name="input">char analisado</param>
        /// <returns>retorna se é consoante</returns>
        public static bool IsConsonant(char input)
        {
            return Regex.Match(input.ToString(), @"^([^aeiouAEIOU0-9\W]+)$").Success;
        }

        /// <summary>
        ///  Retornar o próximo caracter a ser processado na stream
        /// </summary>
        /// <returns></returns>
        public char GetNext()
        {
            if (string.IsNullOrEmpty(_input))
                return new char();

            char nextChar = _input[_lastIndexRead];

            _lastIndexRead++;

            return nextChar;
        }
        /// <summary>
        /// Retornar se a stream ainda contem caracteres para processar.        /// </summary>
        /// <returns></returns>
        public bool HasNext()
        {
            if (string.IsNullOrEmpty(_input))
                return false;

            return _lastIndexRead < _input.Length;
        }
    }
}

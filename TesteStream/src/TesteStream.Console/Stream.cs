using System;

namespace TesteStream.Console
{
    public class Stream : IStream
    {
        private string _input;
        private int _lastIndexRead = 0;

        public Stream(string input) => _input = input;

        public char FirstChar()
        {
            while (HasNext())
            {
                char next = GetNext();
            }
            throw new NotImplementedException();
        }
        /// <summary>
        ///  Retornar o próximo caracter a ser processado na stream
        /// </summary>
        /// <returns></returns>
        public char GetNext()
        {
            if (string.IsNullOrEmpty(_input))
                return new char();

            return _input[_lastIndexRead];
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

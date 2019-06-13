using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteStream.Console
{
    class Program
    {
        static Stream _stream;

        static void Main(string[] args)
        {
            System.Console.WriteLine("Por favor, informe uma stream:");
            var stream = System.Console.ReadLine();

            if (string.IsNullOrEmpty(stream.Trim()))
                System.Console.WriteLine("Nenhuma stream informada");
            else
            {
                _stream = new Stream(stream);

                var result = _stream.FirstChar();

                if (!result.HasValue)
                    System.Console.WriteLine("Nenhuma vogal encontrada dentro dos parâmetros analisados");
                else
                    System.Console.WriteLine($"A vogal '{result.Value}' é o primeiro caracter Vogal da stream que não se repete após a primeira Consoante.");
            }
            System.Console.ReadKey();
        }

    }
}

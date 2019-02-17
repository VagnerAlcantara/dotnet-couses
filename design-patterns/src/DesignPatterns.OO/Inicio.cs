class Inicio
{
    static void Main(string[] args)
    {
        Operacao operacao = new Subtracao();
        new Calcular().MostrarResultado(operacao, 5, 5);

        System.Console.ReadKey();
    }
}


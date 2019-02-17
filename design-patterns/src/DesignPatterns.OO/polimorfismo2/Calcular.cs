class Calcular
{
    public void MostrarResultado(Operacao operacao, double n1, double n2)
    {
        double resultado = operacao.Calcular(n1, n2);
        System.Console.WriteLine("Resultado {0}", resultado);

    }
}


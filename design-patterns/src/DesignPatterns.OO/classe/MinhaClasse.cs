class MinhaClasse
{
    public MinhaClasse()
    {
        Telefone telefone = new Telefone("Preta", "Windows");
        telefone.Ligar("1234-9998");
        telefone.Ligar("011", "1234-9998");
    }
}

class Telefone
{
    private string Cor { get; set; }
    private string SO { get; set; }

    public Telefone(string cor, string so)
    {
        Cor = cor;
        SO = so;
    }

    public void Ligar(string numero)
    {
        System.Console.WriteLine(BemVindo());
        System.Console.WriteLine("Ligando para {0}", numero);
    }

    public void Ligar(string ddd, string numero)
    {
        System.Console.WriteLine(BemVindo());
        System.Console.WriteLine("Ligando para {0} - {1}", ddd, numero);
    }

    public string BemVindo()
    {
        string texto = string.Concat("Telefone ", Cor, "com o sistema operacional ", SO);
        return texto;
    }


    public static void Discar(string numero)
    {
        System.Console.WriteLine("Ligando para {0}", numero);
    }

    //Destrutor
    ~Telefone()
    {
        System.Console.WriteLine("Telefone sendo retirado da memória");
    }
}

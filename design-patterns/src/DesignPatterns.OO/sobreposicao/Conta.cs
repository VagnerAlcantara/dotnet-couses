class Conta
{
    public virtual void Saque(string agenda, string conta, double valor)
    {
        System.Console.WriteLine("Saque, ag: {0} C/C.: {1} valor: {2} ", agenda, conta, valor);
    }
}


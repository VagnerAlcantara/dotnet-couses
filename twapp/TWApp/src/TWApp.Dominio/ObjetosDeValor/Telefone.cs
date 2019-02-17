using TWApp.Compartilhado.Entidades;

namespace TWApp.Dominio.ObjetosDeValor
{
    public class Telefone : ObjetoDeValor
    {
        public Telefone(int dDD, int numero, string tipo)
        {
            DDD = dDD;
            Numero = numero;
            Tipo = tipo;
        }

        public int DDD { get; private set; }
        public int Numero { get; private set; }
        public string Tipo { get; private set; }


        public override string ToString()
        {
            return string.Concat(" (", DDD, ") ", Numero);
        }
    }
}

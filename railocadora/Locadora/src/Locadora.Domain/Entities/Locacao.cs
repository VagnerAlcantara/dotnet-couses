using System;

namespace Locadora.Domain.Entities
{
    public class Locacao
    {
        public int Id { get; private set; }
        public int IdFilme { get; private set; }
        public int IdCliente { get; private set; }
        public DateTime DataRetirada { get; private set; }
        public DateTime DataEntrega { get; set; }

        public Locacao(int? id, int idFilme, int idCliente, DateTime dataRetirada, DateTime dataEntrega)
        {
            if (id.HasValue)
                Id = id.Value;

            this.IdCliente = idCliente;
            this.IdFilme = idFilme;
            this.DataRetirada = dataRetirada;
            this.DataEntrega = dataEntrega;

        }
    }
}

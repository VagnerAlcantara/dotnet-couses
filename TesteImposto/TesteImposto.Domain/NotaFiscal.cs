using System;
using System.Collections.Generic;
using TesteImposto.Shared;

namespace TesteImposto.Domain
{
    [Serializable]
    public class NotaFiscal : Notification
    {
        public int Id { get; set; }
        public int NumeroNotaFiscal { get; set; }
        public int Serie { get; set; }
        public string NomeCliente { get; set; }
        public string EstadoDestino { get; set; }
        public string EstadoOrigem { get; set; }
        public List<NotaFiscalItem> ItensDaNotaFiscal { get; set; }

        private NotaFiscal()
        {
            ItensDaNotaFiscal = new List<NotaFiscalItem>();
        }

        public NotaFiscal(string nomeCliente, string estadoOrigem, string estadoDestino) : this()
        {
            ValidateNotaFiscal(nomeCliente, estadoDestino, estadoOrigem);

            if (IsValid)
                CreateNotaFiscal(nomeCliente, estadoDestino, estadoOrigem);
        }

        public NotaFiscal EmitirNotaFiscal(Pedido pedido)
        {
            if (pedido.IsValid && IsValid)
                AddItem(pedido);

            return this;

        }

        private void CreateNotaFiscal(string nomeCliente, string estadoDestino, string estadoOrigem)
        {
            Id = 0;
            NumeroNotaFiscal = new Random().Next(0, int.MaxValue);
            Serie = new Random().Next(0, int.MaxValue); ;
            NomeCliente = nomeCliente;
            EstadoDestino = estadoOrigem;
            EstadoOrigem = estadoDestino;
        }

        private void AddItem(Pedido pedido)
        {
            string cfop = GetCfop();
            string tipoIcms = GetTipoIcms();
            double? aliquotaIcms = GetAliquotaIcms();

            foreach (PedidoItem itemPedido in pedido.ItensDoPedido)
            {
                double? baseIcms = GetBaseIcms(cfop, itemPedido.ValorItemPedido);

                double? valorIcms = baseIcms * aliquotaIcms;

                if (itemPedido.Brinde)
                {
                    tipoIcms = "60";
                    aliquotaIcms = 0.18;
                    valorIcms = baseIcms * aliquotaIcms;
                }

                NotaFiscalItem notaFiscalItem = new NotaFiscalItem(
                     Id,
                     cfop,
                     tipoIcms,
                     baseIcms,
                     aliquotaIcms,
                     valorIcms,
                     itemPedido.NomeProduto,
                     itemPedido.CodigoProduto,
                     itemPedido.ValorItemPedido,
                     itemPedido.Brinde
                     );

                if (notaFiscalItem.IsValid)
                    ItensDaNotaFiscal.Add(notaFiscalItem);
                else
                    AddError(notaFiscalItem.Errors);

            }
        }

        private void ValidateNotaFiscal(string nomeCliente, string estadoDestino, string estadoOrigem)
        {
            if (string.IsNullOrEmpty(nomeCliente))
                AddError("Nome do cliente é obrigatório");

            if (string.IsNullOrEmpty(estadoDestino))
                AddError("Estado de destino é obrigatório");

            if (string.IsNullOrEmpty(estadoOrigem))
                AddError("Estado de origem é obrigatório");
        }

        private string GetCfop()
        {
            string cfop = string.Empty;

            if ((EstadoOrigem == "SP") && (EstadoDestino == "RJ"))
            {
                cfop = "6.000";
            }
            else if ((EstadoOrigem == "SP") && (EstadoDestino == "PE"))
            {
                cfop = "6.001";
            }
            else if ((EstadoOrigem == "SP") && (EstadoDestino == "MG"))
            {
                cfop = "6.002";
            }
            else if ((EstadoOrigem == "SP") && (EstadoDestino == "PB"))
            {
                cfop = "6.003";
            }
            else if ((EstadoOrigem == "SP") && (EstadoDestino == "PR"))
            {
                cfop = "6.004";
            }
            else if ((EstadoOrigem == "SP") && (EstadoDestino == "PI"))
            {
                cfop = "6.005";
            }
            else if ((EstadoOrigem == "SP") && (EstadoDestino == "RO"))
            {
                cfop = "6.006";
            }
            else if ((EstadoOrigem == "SP") && (EstadoDestino == "SE"))
            {
                cfop = "6.007";
            }
            else if ((EstadoOrigem == "SP") && (EstadoDestino == "TO"))
            {
                cfop = "6.008";
            }
            else if ((EstadoOrigem == "SP") && (EstadoDestino == "SE"))
            {
                cfop = "6.009";
            }
            else if ((EstadoOrigem == "SP") && (EstadoDestino == "PA"))
            {
                cfop = "6.010";
            }
            else if ((EstadoOrigem == "MG") && (EstadoDestino == "RJ"))
            {
                cfop = "6.000";
            }
            else if ((EstadoOrigem == "MG") && (EstadoDestino == "PE"))
            {
                cfop = "6.001";
            }
            else if ((EstadoOrigem == "MG") && (EstadoDestino == "MG"))
            {
                cfop = "6.002";
            }
            else if ((EstadoOrigem == "MG") && (EstadoDestino == "PB"))
            {
                cfop = "6.003";
            }
            else if ((EstadoOrigem == "MG") && (EstadoDestino == "PR"))
            {
                cfop = "6.004";
            }
            else if ((EstadoOrigem == "MG") && (EstadoDestino == "PI"))
            {
                cfop = "6.005";
            }
            else if ((EstadoOrigem == "MG") && (EstadoDestino == "RO"))
            {
                cfop = "6.006";
            }
            else if ((EstadoOrigem == "MG") && (EstadoDestino == "SE"))
            {
                cfop = "6.007";
            }
            else if ((EstadoOrigem == "MG") && (EstadoDestino == "TO"))
            {
                cfop = "6.008";
            }
            else if ((EstadoOrigem == "MG") && (EstadoDestino == "SE"))
            {
                cfop = "6.009";
            }
            else if ((EstadoOrigem == "MG") && (EstadoDestino == "PA"))
            {
                cfop = "6.010";
            }
            if (string.IsNullOrEmpty(cfop))
            {
                cfop = "6.000";
            }
            return cfop;
        }

        private string GetTipoIcms()
        {
            string tipoIcms = string.Empty;

            if (EstadoDestino == EstadoOrigem)
            {
                tipoIcms = "60";
            }
            else
            {
                tipoIcms = "10";
            }

            return tipoIcms;
        }

        private double? GetAliquotaIcms()
        {
            double? aliquotaIcms = null;

            if (EstadoDestino == EstadoOrigem)
            {
                aliquotaIcms = 0.18;
            }
            else
            {
                aliquotaIcms = 0.17;
            }

            return aliquotaIcms;
        }

        private double? GetBaseIcms(string cfop, double valorItemPedido)
        {
            double? baseIcms = null;

            if (cfop == "6.009")
            {
                baseIcms = valorItemPedido * 0.90; //redução de base
            }
            else
            {
                baseIcms = valorItemPedido;
            }

            return baseIcms;
        }
    }
}

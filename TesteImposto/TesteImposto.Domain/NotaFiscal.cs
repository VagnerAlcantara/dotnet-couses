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

        public NotaFiscal(string nomeCliente, string estadoOrigem, string estadoDestino, IList<PedidoItem> pedidoItems) : this()
        {
            ValidateNotaFiscal(nomeCliente, estadoOrigem, estadoDestino);

            if (IsValid)
                CreateNotaFiscal(nomeCliente, estadoOrigem, estadoDestino, pedidoItems);
        }

        /// <summary>
        /// Valida os dados para nota fiscal
        /// </summary>
        /// <param name="nomeCliente">Nome do cliente</param>
        /// <param name="estadoDestino">Estado de destino</param>
        /// <param name="estadoOrigem">Esta de origem</param>
        private void ValidateNotaFiscal(string nomeCliente, string estadoOrigem, string estadoDestino)
        {
            if (string.IsNullOrEmpty(nomeCliente))
                AddError("Nome do cliente é obrigatório");

            if (string.IsNullOrEmpty(estadoDestino))
                AddError("Estado de destino é obrigatório");

            if (string.IsNullOrEmpty(estadoOrigem))
                AddError("Estado de origem é obrigatório");
        }

        /// <summary>
        /// Cria nota fiscal
        /// </summary>
        /// <param name="nomeCliente">Nome do cliente</param>
        /// <param name="estadoDestino">Estado de destino</param>
        /// <param name="estadoOrigem">Esta de origem</param>
        private void CreateNotaFiscal(string nomeCliente, string estadoOrigem, string estadoDestino, IList<PedidoItem> pedidoItems)
        {
            Id = 0;
            NumeroNotaFiscal = new Random().Next(0, int.MaxValue);
            Serie = new Random().Next(0, int.MaxValue); ;
            NomeCliente = nomeCliente;
            EstadoDestino = estadoOrigem;
            EstadoOrigem = estadoDestino;
            ItensDaNotaFiscal = AddItem(pedidoItems);

        }
        
        /// <summary>
        /// Adiciona itens a nota fiscal
        /// </summary>
        /// <param name="pedidoItems">Itens do pedido</param>
        /// <returns>Retorna os itens da nota fiscal</returns>
        private List<NotaFiscalItem> AddItem(IList<PedidoItem> pedidoItems)
        {
            List<NotaFiscalItem> itensDaNotaFiscal = new List<NotaFiscalItem>();

            string cfop = GetCfop();
            string tipoIcms = GetTipoIcms();
            double? aliquotaIcms = GetAliquotaIcms();

            foreach (PedidoItem itemPedido in pedidoItems)
            {
                double descontoSudeste = 10;

                if (Estado.IsSudeste(EstadoOrigem))
                    itemPedido.AplicarDesconto(descontoSudeste);
                else
                    descontoSudeste = 0;

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
                     itemPedido.Brinde,
                     descontoSudeste
                     );

                if (notaFiscalItem.IsValid)
                    itensDaNotaFiscal.Add(notaFiscalItem);
                else
                    AddError(notaFiscalItem.Errors);
            }
            return itensDaNotaFiscal;
        }

        /// <summary>
        /// Falta refatorar, criar objetos especificos para aplicação de regra sem if
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Falta refatorar
        /// </summary>
        /// <returns></returns>
        private string GetTipoIcms()
        {
            string tipoIcms = "10";

            if (EstadoDestino == EstadoOrigem)
                tipoIcms = "60";
            
            return tipoIcms;
        }

        /// <summary>
        /// Falta refatorar
        /// </summary>
        /// <returns></returns>
        private double GetAliquotaIcms()
        {
            double aliquotaIcms = 0.17;

            if (EstadoDestino == EstadoOrigem)
                aliquotaIcms = 0.18;
            
            return aliquotaIcms;
        }

        /// <summary>
        /// Falta refatorar
        /// </summary>
        /// <param name="cfop">CFOP</param>
        /// <param name="valorItemPedido">Valor do item</param>
        /// <returns></returns>
        private double GetBaseIcms(string cfop, double valorItemPedido)
        {
            double baseIcms = valorItemPedido;

            if (cfop == "6.009")
                baseIcms = valorItemPedido * 0.90; //redução de base
            
            return baseIcms;
        }
    }
}

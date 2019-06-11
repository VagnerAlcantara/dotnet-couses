using System;
using TesteImposto.Shared;

namespace TesteImposto.Domain
{
    public class NotaFiscalItem : Notification
    {
        public int Id { get; private set; }
        public int IdNotaFiscal { get; private set; }
        public string Cfop { get; private set; }
        public string TipoIcms { get; private set; }
        public double BaseIcms { get; private set; }
        public double AliquotaIcms { get; private set; }
        public double ValorIcms { get; private set; }
        public string NomeProduto { get; private set; }
        public string CodigoProduto { get; private set; }

        public NotaFiscalItem(int idNotaFiscal, string cfop, string tipoIcms, double? baseIcms, double? aliquotaIcms, double? valorIcms, string nomeProduto, string codigoProduto)
        {
            ValidateNotaFiscalItem(idNotaFiscal, cfop, tipoIcms, baseIcms, aliquotaIcms, valorIcms, nomeProduto, codigoProduto);

            if (IsValid)
                CreateNotalFiscalItem(idNotaFiscal, cfop, tipoIcms, baseIcms.Value, aliquotaIcms.Value, valorIcms.Value, nomeProduto, codigoProduto);
        }
        public void SetIdNotaFiscal(int id)
        {
            IdNotaFiscal = id;
        }

        /// <summary>
        /// Valida o item da nota fiscal
        /// </summary>
        /// <param name="idNotaFiscal">Id da nota fiscal que armazernará o item</param>
        /// <param name="cfop">CFOP do item</param>
        /// <param name="tipoIcms">Tipo do ICMS relacionado ao item</param>
        /// <param name="baseIcms">Base ICMS relacionado ao item</param>
        /// <param name="aliquotaIcms">Aliquota ICMS relacionado ai item</param>
        /// <param name="valorIcms">Valor do ICMS relacionado ao item</param>
        /// <param name="nomeProduto">Nome do produto</param>
        /// <param name="codigoProduto">Código do produto</param>
        private void ValidateNotaFiscalItem(int idNotaFiscal, string cfop, string tipoIcms, double? baseIcms, double? aliquotaIcms, double? valorIcms, string nomeProduto, string codigoProduto)
        {
            if (idNotaFiscal == 0)
                AddError("Nota Fiscal inválida");

            if (string.IsNullOrEmpty(cfop))
                AddError("CFOP inválido");

            if (string.IsNullOrEmpty(tipoIcms))
                AddError("Tipo do ICMS inválido");

            if (!baseIcms.HasValue || baseIcms <= 0)
                AddError("Base ICMS inválido");

            if (!aliquotaIcms.HasValue || aliquotaIcms <= 0)
                AddError("Aliquota ICMS inválido");

            if (!valorIcms.HasValue || valorIcms <= 0)
                AddError("Valor dp ICMS inválido");

            if (string.IsNullOrEmpty(nomeProduto))
                AddError("Produto inválido");

            if (string.IsNullOrEmpty(codigoProduto))
                AddError("Código do produto inválido");
        }
       
        /// <summary>
        /// Cria um item para geração de nota fiscal
        /// </summary>
        /// <param name="idNotaFiscal">Id da nota fiscal que armazernará o item</param>
        /// <param name="cfop">CFOP do item</param>
        /// <param name="tipoIcms">Tipo do ICMS relacionado ao item</param>
        /// <param name="baseIcms">Base ICMS relacionado ao item</param>
        /// <param name="aliquotaIcms">Aliquota ICMS relacionado ai item</param>
        /// <param name="valorIcms">Valor do ICMS relacionado ao item</param>
        /// <param name="nomeProduto">Nome do produto</param>
        /// <param name="codigoProduto">Código do produto</param>
        private void CreateNotalFiscalItem(int idNotaFiscal, string cfop, string tipoIcms, double baseIcms, double aliquotaIcms, double valorIcms, string nomeProduto, string codigoProduto)
        {
            Id = new Random().Next(Int32.MaxValue); ;
            IdNotaFiscal = idNotaFiscal;
            Cfop = cfop;
            TipoIcms = tipoIcms;
            BaseIcms = baseIcms;
            AliquotaIcms = aliquotaIcms;
            ValorIcms = valorIcms;
            NomeProduto = nomeProduto;
            CodigoProduto = codigoProduto;
        }
    }
}

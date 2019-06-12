using System;
using TesteImposto.Shared;

namespace TesteImposto.Domain
{
    [Serializable]
    public class NotaFiscalItem : Notification
    {
        public int Id { get; set; }
        public int IdNotaFiscal { get; set; }
        public string Cfop { get; set; }
        public string TipoIcms { get; set; }
        public double BaseIcms { get; set; }
        public double AliquotaIcms { get; set; }
        public double ValorIcms { get; set; }
        public string NomeProduto { get; set; }
        public string CodigoProduto { get; set; }

        public double BaseCalculoIpi { get; set; }
        public double AliquotaIpi { get; set; }
        public double ValorIpi { get; set; }

        private NotaFiscalItem()
        {

        }

        /// <summary>
        /// Item da nota fiscal
        /// </summary>
        /// <param name="idNotaFiscal">Id da nota fiscal que armazernará o item</param>
        /// <param name="cfop">CFOP do item</param>
        /// <param name="tipoIcms">Tipo do ICMS relacionado ao item</param>
        /// <param name="baseIcms">Base ICMS relacionado ao item</param>
        /// <param name="aliquotaIcms">Aliquota ICMS relacionado ai item</param>
        /// <param name="valorIcms">Valor do ICMS relacionado ao item</param>
        /// <param name="nomeProduto">Nome do produto</param>
        /// <param name="codigoProduto">Código do produto</param>
        /// <param name="valorProduto">Base cálculo IPI</param>
        /// <param name="brinde">Se o item é um brinde</param>
        public NotaFiscalItem(int idNotaFiscal, string cfop, string tipoIcms, double? baseIcms, double? aliquotaIcms, double? valorIcms, string nomeProduto, string codigoProduto, double? valorProduto, bool brinde)
        {
            ValidateNotaFiscalItem(idNotaFiscal, cfop, tipoIcms, baseIcms, aliquotaIcms, valorIcms, nomeProduto, codigoProduto);

            if (IsValid)
                CreateNotalFiscalItem(idNotaFiscal, cfop, tipoIcms, baseIcms.Value, aliquotaIcms.Value, valorIcms.Value, nomeProduto, codigoProduto, valorProduto.Value, brinde);
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
            if (string.IsNullOrEmpty(cfop))
                AddError("CFOP inválido");

            if (string.IsNullOrEmpty(tipoIcms))
                AddError("Tipo do ICMS inválido");

            if (!baseIcms.HasValue || baseIcms <= 0)
                AddError("Base ICMS inválido");

            if (!aliquotaIcms.HasValue || aliquotaIcms <= 0)
                AddError("Aliquota ICMS inválido");

            if (!valorIcms.HasValue || valorIcms <= 0)
                AddError("Valor ICMS inválido");

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
        /// <param name="valorProduto">Valor do item</param>
        /// <param name="brinde">Se o item é um brinde</param>
        private void CreateNotalFiscalItem(int idNotaFiscal, string cfop, string tipoIcms, double baseIcms, double aliquotaIcms, double valorIcms, string nomeProduto, string codigoProduto, double valorProduto, bool brinde)
        {
            Id = 0;
            IdNotaFiscal = idNotaFiscal;
            Cfop = cfop;
            TipoIcms = tipoIcms;
            BaseIcms = Math.Round(baseIcms, 4);
            AliquotaIcms = Math.Round(aliquotaIcms, 4);
            ValorIcms = Math.Round(valorIcms, 4);
            NomeProduto = nomeProduto;
            CodigoProduto = codigoProduto;
            BaseCalculoIpi = Math.Round(valorProduto, 4);
            AliquotaIpi = Math.Round((brinde ? 0f : 10f), 4);
            ValorIpi = Math.Round(BaseCalculoIpi * AliquotaIpi, 4);
        }
    }
}

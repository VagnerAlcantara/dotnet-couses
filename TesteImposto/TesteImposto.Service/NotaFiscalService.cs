using System;
using TesteImposto.Data;
using TesteImposto.Domain;
using TesteImposto.Domain.Interfaces.Services;
using TesteImposto.Shared;
using TesteImposto.Shared.Xml;

namespace TesteImposto.Service
{
    public class NotaFiscalService : Notification, INotaFiscalService
    {
        private readonly NotaFiscalRepository _notaFiscalRepository;

        public NotaFiscalService()
        {
            _notaFiscalRepository = new NotaFiscalRepository();
        }
        /// <summary>
        /// Gera nota fiscal com base num pedido
        /// </summary>
        /// <param name="pedido">Dados do pedido para geração da nota fiscal</param>
        public void GerarNotaFiscal(Pedido pedido)
        {
            if (!pedido.IsValid)
            {
                AddError(pedido.Errors);
                return;
            }
            NotaFiscal notaFiscal = new NotaFiscal(pedido.NomeCliente, pedido.EstadoDestino, pedido.EstadoOrigem);

            notaFiscal = notaFiscal.EmitirNotaFiscal(pedido);

            if (!notaFiscal.IsValid)
            {
                AddError(notaFiscal.Errors);
                return;
            }

            if (GerarXml(notaFiscal))
                _notaFiscalRepository.GravarNotaFiscal(notaFiscal);

            if (!_notaFiscalRepository.IsValid)
                AddError(_notaFiscalRepository.Errors);
        }

        /// <summary>
        /// Gera o arquivo Xml com dados da nota fiscal num diretório parametrizado pela equipe pré-definido
        /// </summary>
        /// <param name="notaFiscal">Dados da nota fiscal para geração do arquivo Xml</param>
        /// <returns></returns>
        private bool GerarXml(NotaFiscal notaFiscal)
        {
            bool sucesso = false;
            try
            {
                XmlShared.CreateXmlFile<NotaFiscal>(notaFiscal);

                sucesso = true;
            }
            catch (Exception)
            {
                AddError("Erro ao gerar XML");
            }

            return sucesso;
        }
    }
}

using Locadora.Data;
using Locadora.Domain.Entities;
using Locadora.Domain.Interface.BLL;
using System;
using System.Collections.Generic;

namespace Locadora.BLL
{
    public class LocacaoBusiness : ILocacaoBusiness
    {
        private LocacaoRepository  _locacaoRepository;

        public LocacaoBusiness()
        {
            _locacaoRepository = new LocacaoRepository();
        }

        public void Adicionar(Locacao entity)
        {
            _locacaoRepository.Adicionar(entity);
        }

        public void Alterar(Locacao entity)
        {
            _locacaoRepository.Alterar(entity);
        }

        public void Dispose()
        {
            _locacaoRepository.Dispose();
        }

        public void Excluir(int id)
        {
            _locacaoRepository.Excluir(id);
        }

        public Locacao Obter(int id)
        {
            throw new NotImplementedException();
        }

        public List<Locacao> ObterPorCliente(int idCliente)
        {
            return _locacaoRepository.ObterPorCliente(idCliente);
        }
    }
}

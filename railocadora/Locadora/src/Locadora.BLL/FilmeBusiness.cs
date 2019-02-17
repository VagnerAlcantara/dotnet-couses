using System.Collections.Generic;
using Locadora.Data;
using Locadora.Domain.Entities;
using Locadora.Domain.Interface.BLL;

namespace Locadora.BLL
{
    public class FilmeBusiness : IFilmeBusiness
    {

        private FilmeRepository _filmeRepository;

        public FilmeBusiness()
        {
            _filmeRepository = new FilmeRepository();
        }

        public void Adicionar(Filme entity)
        {
            _filmeRepository.Adicionar(entity);
        }

        public void Alterar(Filme entity)
        {
            _filmeRepository.Alterar(entity);
        }

        public void Dispose()
        {
            _filmeRepository.Dispose();
        }

        public void Excluir(int id)
        {
            _filmeRepository.Excluir(id);
        }

        public Filme Obter(int id)
        {
            return _filmeRepository.Obter(id);
        }

        public IList<Filme> Obter(string titulo)
        {
            return _filmeRepository.Obter(titulo);
        }

        public IList<Filme> Obter()
        {
            return _filmeRepository.Obter();
        }
    }
}

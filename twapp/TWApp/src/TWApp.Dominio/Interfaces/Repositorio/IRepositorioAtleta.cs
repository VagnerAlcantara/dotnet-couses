using TWApp.Dominio.Entidades;

namespace TWApp.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioAtleta
    {
        void Salvar(Atleta atleta);
        Atleta Obter(int id);
        bool ExisteCpf(string cpf);
    }
}

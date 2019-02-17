
namespace GerenciadorUsuarioService.Dominio.Entidades
{
    public class Endereco
    {
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Uf { get; set; }
        public int IdMunicipio { get; set; }
        public string MunicipioNome { get; set; }
    }
}

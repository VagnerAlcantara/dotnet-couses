
using System.ComponentModel;

namespace GerenciadorUsuarioService.Dominio.Entidades
{
    public class Usuario
    {
        public Usuario()
        {
            
        }

        [DisplayName("ValidaCPF")]
        public int ValidaCpf { get; set; }
        [DisplayName("RGAlteraSenha")]
        public int RgAlteraSenha { get; set; }

        [DisplayName("Instituição/ Origem")]
        public string Instituicao_Origem { get; set; }
        [DisplayName("IDLDAP")]
        public string IDLDAP { get; set; }
        [DisplayName("Nome Completo")]
        public string Nome { get; set; }
        [DisplayName("Primeiro nome")]
        public string PrimeironoNome { get; set; }
        [DisplayName("Sobrenome")]
        public string Sobrenome { get; set; }
        [DisplayName("RG")]
        public string RG { get; set; }
        [DisplayName("Orgão Expedidor")]
        public string OrgaoExpedidor { get; set; }
        [DisplayName("UF (RG)")]
        public string UfEmissor { get; set; }
        [DisplayName("CPF")]
        public string CPF { get; set; }
        [DisplayName("Registro do Servidor")]
        public string RegistroServidor { get; set; }
        [DisplayName("Data de nascimento")]
        public string DataNascimento { get; set; }
        [DisplayName("Cargo")]
        public string Cargo { get; set; }
        [DisplayName("Depto.")]
        public string Departamento { get; set; }
        //Endereço
        [DisplayName("Endereço")]
        public string Logradouro { get; set; }
        [DisplayName("Número")]
        public string Numero { get; set; }
        [DisplayName("Complemento")]
        public string Complemento { get; set; }
        [DisplayName("Bairro")]
        public string Bairro { get; set; }
        [DisplayName("Município")]
        public string Cidade { get; set; }
        [DisplayName("UF")]
        public string UF { get; set; }
        [DisplayName("CEP")]
        public string CEP { get; set; }
        //
        [DisplayName("Sexo")]
        public string Sexo { get; set; }
        //Contato
        [DisplayName("E-mail")]
        public string Email { get; set; }
        [DisplayName("E-mail Servidor")]
        public string EmailServidor { get; set; }
        [DisplayName("E-mail Professor")]
        public string EmailProfessor { get; set; }
        [DisplayName("Tel. Residencial")]
        public string TelefoneResidencial { get; set; }
        [DisplayName("DDD")]
        public string DddResidencial { get; set; }
        [DisplayName("Tel. Comercial")]
        public string TelefoneComercial { get; set; }
        [DisplayName("DDD")]
        public string DddComercial { get; set; }
        [DisplayName("Ramal")]
        public string Ramal { get; set; }
        [DisplayName("Tel. Celular")]
        public string TelefoneCelular { get; set; }
        [DisplayName("DDD")]
        public string DddCelular { get; set; }
        //
        //Dados bancário
        [DisplayName("Número do Banco")]
        public string NumeroBanco { get; set; }
        [DisplayName("Agência")]
        public string Agencia { get; set; }
        [DisplayName("Número da conta")]
        public string NumeroConta { get; set; }
        [DisplayName("Dígito")]
        public string Digito { get; set; }
        [DisplayName("Tipo da conta")]
        public string TipoConta { get; set; }
        [DisplayName("Vinculado FDE")]
        public string VinculadoFDE { get; set; }
        //

        public int? IdArvore { get; set; }

        [DisplayName("Árvore")]
        public string Arvore { get; set; }
        [DisplayName("AdsPath")]
        public string AdsPath { get; set; }
        public string Senha { get; set; }

    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TWApp.Dominio.ObjetosDeValor;
using System.Linq;

namespace TWApp.Dominio.Testes.ObjetoValor
{
    [TestClass]
    public class CepTestes
    {
        [TestMethod]
        [TestCategory("CEP")]
        public void DadoUmCepVazioDeveRetornarInvalido()
        {
            Cep cep = new Cep("");

            Assert.AreEqual(cep.EValido(), false, cep.Notificacoes.FirstOrDefault().Mensagem);
        }

        [TestMethod]
        [TestCategory("CEP")]
        public void DadoUmCepInvalidoDeveRetornarInvalido()
        {
            Cep cep = new Cep("07140");

            Assert.AreEqual(cep.EValido(), false, cep.Notificacoes.FirstOrDefault().Mensagem);
        }

        [TestMethod]
        [TestCategory("CEP")]
        public void DadoUmCepValidoDeveRetornarValido()
        {
            Cep cep = new Cep("07140400");

            Assert.AreEqual(cep.EValido(), true, cep.Notificacoes.FirstOrDefault().Mensagem);
        }
    }
}

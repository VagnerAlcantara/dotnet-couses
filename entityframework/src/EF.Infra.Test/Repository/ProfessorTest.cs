using System;
using EF.Domain.Entities;
using EF.Domain.Interface.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EF.Infra.Test.Repository
{
    [TestClass]
    public class ProfessorTest
    {
        [TestMethod]
        public void Adicionar_Professor_Test()
        {
            try
            {

                Professor professor = new Professor("Professor", null, null);

                var mock = new Mock<IProfessorRepository>();

                mock.Setup(x => x.Adicionar(professor));

            }
            catch (Exception ex)
            {
                Assert.Fail("Falha ao testar: " + ex.Message);
            }
        }
    }
}

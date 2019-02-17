using EF.Domain.Entities;
using EF.Domain.Interface.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EF.Infra.Test.Repository
{
    [TestClass]
    public class AlunoTest
    {
        private IAlunoRepository _alunoRepository;


        public AlunoTest(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        [TestMethod]
        public void Adicionar_Aluno_Test()
        {
            Professor professor = new Professor("Professor 01", null, null);

        }
    }
}

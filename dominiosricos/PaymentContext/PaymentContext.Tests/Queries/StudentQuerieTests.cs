using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;
using PaymentoContext.Domain.Entities;

namespace PaymentContext.Tests.Queries
{
    [TestClass]
    public class StudentQuerieTests
    {
        IList<Student> _students;

        public StudentQuerieTests()
        {
            for (int i = 0; i < 10; i++)
            {
                _students.Add(new Student(
                    new Name("Aluno", i.ToString()),
                    new Document("11111111111" + i.ToString(), EDocumentType.CPF),
                    new Email(i.ToString() + "@email.com")));
            }
        }

        [TestMethod]
        public void ShouldReturnNullWhenDocumentNotExists()
        {
            var exp = StudentQueries.GetStudentInfo("12345678911");
            var stud = _students.AsQueryable().Where(exp);

            Assert.AreEqual(null, stud);
        }
        [TestMethod]
        public void ShouldReturnStudentWhenDocumentExists()
        {
            var exp = StudentQueries.GetStudentInfo("111111111111");
            var stud = _students.AsQueryable().Where(exp);

            Assert.AreNotEqual(null, stud);
        }
    }
}

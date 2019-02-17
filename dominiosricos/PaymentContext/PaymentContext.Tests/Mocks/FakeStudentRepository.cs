using PaymentContext.Domain.Repositories;
using PaymentoContext.Domain.Entities;

namespace PaymentContext.Tests.Mocks
{
    public class FakeStudentRepository : IStudentRepository
    {
        public void CreateSubscription(Student student)
        {
            throw new System.NotImplementedException();
        }

        public bool DocumentExists(string document)
        {
            if (document == "999999999")
                return true;

            return false;
        }

        public bool EmailExists(string email)
        {
            if (email == "email@email.com")
                return true;

            return false;
        }
    }
}
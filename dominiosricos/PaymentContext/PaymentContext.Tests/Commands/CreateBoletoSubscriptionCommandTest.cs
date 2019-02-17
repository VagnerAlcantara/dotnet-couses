using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class CreateBoletoSubscriptionCommandTest
    {
        [TestMethod]
        public void ShouldReturnErrorWhenNameIsInvalid()
        {
           var command = new CreateBoletoSubscriptionCommand();
           command.FirstName = "";

           command.Validate();

           Assert.AreEqual(false, command.Valid);
        }
        
    }
}

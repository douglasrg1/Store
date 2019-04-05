using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Commands.CustomerCommand.Inputs;
using Store.Domain.StoreContext.Handlers;
using Store.Tests.Fake;

namespace Store.Tests.Handlers
{
    [TestClass]
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand("Douglas","Rocha","09752725600","teste@teste.com","38914821");

            var handler = new CustomerHandlers(new FakeCustomerRepository(),new FakeEmailService());

            var result = handler.Handle(command);

            Assert.AreNotEqual(false,result);
            Assert.AreEqual(true,handler.IsValid);
        }
    }
}

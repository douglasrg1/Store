using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Commands.CustomerCommand.Inputs;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Enums;
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
            var ad = new AddAddressCommand("Rua dona mariinha", "96", "Casa 2", "Santo Antonio", "Viçosa", "MG", "Brasil"
                                , "36570000", EAddressType.Shipping);
            var ad2 = new AddAddressCommand("Rua dona mariinha", "96", "Casa 2", "Santo Antonio", "Viçosa", "MG", "Brasil"
                                , "36570000", EAddressType.Shipping);

            var address = new List<AddAddressCommand>();
            address.Add(ad);
            address.Add(ad2);

            var command = new CreateCustomerCommand("Douglas", "Rocha", "09752725600", "teste@teste.com", "38914821", address);

            var handler = new CustomerHandlers(new FakeCustomerRepository(), new FakeEmailService());

            var result = handler.Handle(command);
            Console.WriteLine(result);

            Assert.AreNotEqual(false, result.Success);
            Assert.AreEqual(true, handler.IsValid);
        }
        [TestMethod]
        public void ShouldUpdateCustomerWhenCommandIsValid()
        {
            var ad = new AddAddressCommand("Rua dona mariinha", "96", "Casa 2", "Santo Antonio", "Viçosa", "MG", "Brasil"
                                , "36570000", EAddressType.Shipping);
            var ad2 = new AddAddressCommand("Rua dona mariinha", "96", "Casa 2", "Santo Antonio", "Viçosa", "MG", "Brasil"
                                , "36570000", EAddressType.Shipping);

            var address = new List<AddAddressCommand>();
            address.Add(ad);
            address.Add(ad2);

            var command = new UpdateCustomerCommand(Guid.NewGuid(),"Douglas", "Rocha", "09752725600", "teste@teste.com", "38914821", address);

            var handler = new CustomerHandlers(new FakeCustomerRepository(), new FakeEmailService());

            var result = handler.Handle(command);
            Console.WriteLine(result);

            Assert.AreNotEqual(false, result.Success);
            Assert.AreEqual(true, handler.IsValid);
        }
        
    }
}

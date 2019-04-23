using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Commands.OrderCommands.Inputs;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Handlers;
using Store.Domain.StoreContext.ValueObjects;
using Store.Tests.Fake;

namespace Store.Tests.Handlers
{
    [TestClass]
    public class OrderHandlersTests
    {
        [TestMethod]
        public void ShouldReturtrueWhenOrderIsValid()
        {
            List<OrderItemCommand> items = new List<OrderItemCommand>(); 

            var Item1 = new OrderItemCommand(Guid.NewGuid(),10.23m,5);
            var Item2 = new OrderItemCommand(Guid.NewGuid(),15.23m,5);
            var Item3 = new OrderItemCommand(Guid.NewGuid(),35.23m,5);

            items.Add(Item1);
            items.Add(Item2);
            items.Add(Item3);

            var placeOrderCommand = new PlaceOrderCommand(Guid.NewGuid(),items);
            var orderHandler = new OrderHandlers(new FakeOrderRepository());

            orderHandler.Handle(placeOrderCommand);

            Assert.IsTrue(orderHandler.IsValid);
        }
    }
}

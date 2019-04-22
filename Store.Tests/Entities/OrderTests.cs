using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Enums;
using Store.Domain.StoreContext.ValueObjects;

namespace Store.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
        private Product _mouse;
        private Product _keyboard;
        private Product _chair;
        private Product _phone;
        private Customer _customer;
        private Order _order;
        public OrderTests()
        {
            var name = new Name("Douglas", "Rocha");
            var document = new Document("12345678912");
            var email = new Email("douglas@teste.com.br");
            _customer = new Customer(name, document, email, "31987367301");
            _order = new Order(_customer.Id);
            _mouse = new Product("mouse", "mouse", "mouse.png", 10, 10);
            _keyboard = new Product("teclado", "teclado", "teclado.png", 10, 10);
            _chair = new Product("chair", "chair", "chair.png", 10, 10);
            _phone = new Product("fone", "fone", "fone.png", 10, 10);
        }

        [TestMethod]
        public void ShouldCreateOrderWhenValid()
        {
            Assert.AreEqual(true, _order.IsValid);

        }
        [TestMethod]
        public void StatusSholdBeCreatedWhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);

        }
        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidsItens()
        {
            _order.Additem(new OrderItem(_chair, 5, 10));
            _order.Additem(new OrderItem(_phone, 5, 10));

            Assert.AreEqual(2, _order.OrderItens.Count());
        }
        [TestMethod]
        public void ShouldReturnFiveQuantityOnHandWhenAddedFiveItensInNewOrder()
        {   
            _order.Additem(new OrderItem(_chair, 5, 10));
            _order.Additem(new OrderItem(_phone, 5, 10));

            Assert.AreEqual(5, _chair.QuantityOnHand);
            Assert.AreEqual(5, _phone.QuantityOnHand);
        }
        [TestMethod]
        public void ShouldReturnStatusPaidWhenOrderIsPaid()
        {
            _order.Pay();

            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }
        [TestMethod]
        public void ShouldReturnTwoShippingsWhenPurchaseTenProducts()
        {
            _order.Additem(new OrderItem(_mouse, 1, 10));
            _order.Additem(new OrderItem(_keyboard, 1, 10));
            _order.Additem(new OrderItem(_mouse, 1, 10));
            _order.Additem(new OrderItem(_keyboard, 1, 10));
            _order.Additem(new OrderItem(_mouse, 1, 10));
            _order.Additem(new OrderItem(_keyboard, 1, 10));
            _order.Additem(new OrderItem(_mouse, 1, 10));
            _order.Additem(new OrderItem(_mouse, 1, 10));
            _order.Ship();
            Assert.AreEqual(2, _order.Deliveries.Count());

        }
        [TestMethod]
        public void ShouldReturnStatusCanceledWhenOrderCanceled()
        {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);

        }
        [TestMethod]
        public void ShouldCancelShippingsWhenOrderIsCanceled()
        {
            foreach (var x in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled,x.Status);
            }

        }

    }
}

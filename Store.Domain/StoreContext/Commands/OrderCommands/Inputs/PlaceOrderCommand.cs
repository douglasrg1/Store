using System;
using System.Collections;
using System.Collections.Generic;
using Store.Shared.Command;

namespace Store.Domain.StoreContext.Commands.OrderCommands.Inputs
{

    public class PlaceOrderCommand : ICommand
    {
        private readonly ICollection<OrderItemCommand> _orderItens;
        public PlaceOrderCommand(Guid customer, IList<OrderItemCommand> orderItems)
        {
            Customer = customer;
            _orderItens = orderItems;
        }

        public Guid Customer { get; private set; }
        public IEnumerable<OrderItemCommand> OrderItems { get{return _orderItens;} }
    }

    public class OrderItemCommand : ICommand
    {
        public OrderItemCommand(Guid product, decimal price, decimal quantity)
        {
            this.product = product;
            this.price = price;
            this.quantity = quantity;
        }

        public Guid product { get; private set; }
        public decimal price { get; private set; }
        public decimal quantity { get; private set; }
    }
}
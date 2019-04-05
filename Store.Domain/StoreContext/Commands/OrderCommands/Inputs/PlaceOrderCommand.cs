using System;
using System.Collections;
using System.Collections.Generic;
using Store.Shared.Command;

namespace Store.Domain.StoreContext.Commands.OrderCommands.Inputs
{

    public class PlaceOrderCommand : ICommand
    {
        public Guid Customer { get; private set; }
        public IList<OrderItemCommand> OrderItems { get; private set; }
    }

    public class OrderItemCommand
    {
        public Guid product { get; private set; }
        public decimal price { get; private set; }
        public decimal quantity { get; private set; }
    }
}
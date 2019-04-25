using System;
using Store.Shared.Command;

namespace Store.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class ShipOrderCommand : ICommand
    {
        public ShipOrderCommand(DateTime estimatedDelivery,Guid orderId)
        {
            EstimatedDelivery = estimatedDelivery;
            OrderId = orderId;
        }

        public DateTime EstimatedDelivery { get; private set; }
        public Guid OrderId { get; private set; }

    }
}
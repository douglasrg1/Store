using System.Linq;
using FluentValidator;
using Store.Domain.StoreContext.Commands;
using Store.Domain.StoreContext.Commands.OrderCommands.Inputs;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Repositories;
using Store.Shared.Command;

namespace Store.Domain.StoreContext.Handlers
{

    public class OrderHandlers : Notifiable,
     ICommandHandler<PlaceOrderCommand>,
     ICommandHandler<ShipOrderCommand>
    {
        private readonly IOrderRepository _reposotory;
        public OrderHandlers(IOrderRepository orderRepository)
        {
            _reposotory = orderRepository;
        }
        public ICommandResult Handle(PlaceOrderCommand Command)
        {
            //criar entidades
            var order = new Order(Command.Customer);

            if (Command.OrderItems.Count() > 0)
            {
                foreach (var item in Command.OrderItems)
                {
                    var product = _reposotory.GetProductById(item.product);

                    var i = new OrderItem(new Product(
                        item.product,
                        product.Title,product.Description,
                        product.Image,product.Price,
                        product.QuantityOnHand), item.quantity, item.price);

                    order.Additem(i);
                }
            }

            if(Invalid)
                return new Result(false,"Os seguintes campos estão com dados incorretos",order.Notifications);

            _reposotory.Save(order);

            return new Result(true,"Dados adicionados com sucesso",new{NumberOrder = order.NumberOrder,CreateDate = order.CreateDate,Status = order.Status});
        }

        public ICommandResult Handle(ShipOrderCommand Command)
        {
            //cria a entidade
            var delivery = new Delivery(Command.EstimatedDelivery,Command.OrderId);
            AddNotifications(delivery.Notifications);

            if(Invalid)
                return new Result(false,"Os seguintes campos estão com dados incorretos",delivery.Notifications);

            _reposotory.AddShip(delivery);

            return new Result(true,"Entrega adicionado ao pedido",new{NumberShip = delivery.Id});

        }
    }
}
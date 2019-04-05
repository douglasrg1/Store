using FluentValidator;
using Store.Domain.StoreContext.Commands.OrderCommands.Inputs;
using Store.Shared.Command;

namespace Store.Domain.StoreContext.Handlers
{

    public class OrderHandlers : Notifiable,
     ICommandHandler<PlaceOrderCommand>
    {
        public ICommandResult Handle(PlaceOrderCommand Command)
        {
            throw new System.NotImplementedException();
        }
    }
}
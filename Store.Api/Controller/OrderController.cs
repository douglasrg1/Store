using Microsoft.AspNetCore.Mvc;
using Store.Domain.StoreContext.Commands.OrderCommands.Inputs;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Handlers;
using Store.Domain.StoreContext.Repositories;
using Store.Shared.Command;

namespace Store.Api.Controllers.OrderController
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _repository;
        private readonly OrderHandlers _handle;
        public OrderController(IOrderRepository repository, OrderHandlers handle)
        {
            _repository = repository;
            _handle = handle;
        }

        [HttpPost]
        [Route("v1/order")]
        public ICommandResult PostOrder([FromBody]PlaceOrderCommand Order)
        {
            return _handle.Handle(Order);
        }
    }
}
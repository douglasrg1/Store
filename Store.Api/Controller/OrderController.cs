using Microsoft.AspNetCore.Mvc;
using Store.Domain.StoreContext.Commands.OrderCommands.Inputs;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Handlers;
using Store.Domain.StoreContext.Repositories;

namespace Store.Api.Controllers.OrderController
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _repository;
        private readonly OrderHandlers _handle;
        public OrderController(IOrderRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("v1/order")]
        public void PostOrder([FromBody]PlaceOrderCommand Order)
        {
            _handle.Handle(Order);
        }
    }
}
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.StoreContext.Commands.CustomerCommand.Inputs;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Handlers;
using Store.Domain.StoreContext.Queries;
using Store.Domain.StoreContext.Repositories;
using Store.Shared.Command;

namespace Store.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly CustomerHandlers _handle;
        public CustomerController(ICustomerRepository repository,CustomerHandlers handle)
        {
            _repository = repository;
            _handle = handle;
        }

        [HttpGet]
        [Route("v1/clientes")]
        public IEnumerable <ListCustomerQueryResult> Get()
        {
            return _repository.Get();
        }
        [HttpGet]
        [Route("v1/clientes/{id}")]
        public CustomerQueryResult GetById(Guid id )
        {
            return _repository.GetById(id);
        }

        [HttpGet]
        [Route("v1/clientes/{id}/orders")]
        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {
            return _repository.GetOrders(id);
        }

        [HttpPost]
        [Route("v1/clientes")]
        public ICommandResult PostCustomer([FromBody]CreateCustomerCommand customer)
        {
            var result = _handle.Handle(customer);
            
            return result;
        }

        [HttpPut]
        [Route("v1/clientes")]
        public ICommandResult PutCustomer([FromBody]UpdateCustomerCommand customer)
        {
            var result = _handle.Handle(customer);
            
            return result;
        }

        [HttpDelete]
        [Route("v1/clientes/{id}")]
        public Customer DeleteCustomer(Guid id)
        {
            return null;
        }
    }
}
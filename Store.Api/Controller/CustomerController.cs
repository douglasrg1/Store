using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.StoreContext.Commands.CustomerCommand.Inputs;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Queries;
using Store.Domain.StoreContext.Repositories;

namespace Store.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("clientes")]
        public IEnumerable <ListCustomerQueryResult> Get()
        {
            return _repository.Get();
        }
        [HttpGet]
        [Route("clientes/{id}")]
        public CustomerQueryResult GetById(Guid id )
        {
            return _repository.GetById(id);
        }

        [HttpGet]
        [Route("clientes/{id}/orders")]
        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {
            return _repository.GetOrders(id);
        }

        [HttpPost]
        [Route("clientes")]
        public Customer PostCustomer([FromBody]CreateCustomerCommand customer)
        {
            return null;
        }

        [HttpPut]
        [Route("clientes")]
        public Customer PutCustomer([FromBody]Customer customer)
        {
            return null;
        }

        [HttpDelete]
        [Route("clientes/{id}")]
        public Customer DeleteCustomer(Guid id)
        {
            return null;
        }
    }
}
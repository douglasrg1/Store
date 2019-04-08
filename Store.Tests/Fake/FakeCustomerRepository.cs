using System;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Queries;
using Store.Domain.StoreContext.Repositories;

namespace Store.Tests.Fake
{

    public class FakeCustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
             return false;
        }

        public CustomerOrderCountResults GetCustomerOrders(string document)
        {
            return new CustomerOrderCountResults(Guid.NewGuid(),"teste","09752725600",2);
        }

        public void Remove(Customer customer)
        {
            
        }

        public void Save(Customer customer)
        {
            
        }

        public void Update(Customer customer)
        {
           
        }
    }
}
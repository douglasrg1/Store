using System;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Queries;
using Store.Domain.StoreContext.Repositories;

namespace Store.Tests.Fake
{
    public class FakeOrderRepository : IOrderRepository
    {
        public ProductQueryResult GetProductById(Guid id)
        {
            return new ProductQueryResult("teste","teste order","teste.img",10,10);
        }

        public void Save(Order order)
        {
            
        }
    }
}
using System;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Repositories;

namespace Store.Infra.StoreContext.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public Product GetProductById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
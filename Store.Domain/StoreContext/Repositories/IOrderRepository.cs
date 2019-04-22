using System;
using Store.Domain.StoreContext.Entities;

namespace Store.Domain.StoreContext.Repositories
{
    public interface IOrderRepository
    {
        Product GetProductById(Guid id);
        void Save(Order order);
    }
}
using System;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Queries;

namespace Store.Domain.StoreContext.Repositories
{
    public interface IOrderRepository
    {
        ProductQueryResult GetProductById(Guid id);
        void Save(Order order);
        void AddShip(Delivery delivery);
    }
}
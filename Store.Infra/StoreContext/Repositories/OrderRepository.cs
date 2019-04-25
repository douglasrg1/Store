using System;
using System.Data;
using System.Linq;
using Dapper;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Queries;
using Store.Domain.StoreContext.Repositories;
using Store.Infra.StoreContext.DataContext;

namespace Store.Infra.StoreContext.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreDataContext _context;
        public OrderRepository(StoreDataContext context)
        {
            _context = context;
        }

        public void AddShip(Delivery delivery)
        {
            _context.Connection.Execute(
                "spAddOrderShip",
                new{Id = delivery.Id, OrderId = delivery.OrderId,CreateDate = delivery.CreateDate,
                    EstimatedDeliveryDate = delivery.EstimatedDeliveryDate,Status = delivery.Status},

                commandType:CommandType.StoredProcedure
            );
        }

        public ProductQueryResult GetProductById(Guid id)
        {
            return _context.Connection.Query<ProductQueryResult>
            ("spReturnProduct",
            new { Id = id },
            commandType: CommandType.StoredProcedure)
            .FirstOrDefault();
        }

        public void Save(Order order)
        {
            _context.Connection.Execute(
                "spSaveOrder",
                new
                {
                    Id = order.Id,
                    CustomerId = order.Customer,
                    CreateDate = order.CreateDate,
                    Status = order.Status,
                    NumberOrder = order.NumberOrder,
                    Total = order.Total
                },
                commandType: CommandType.StoredProcedure

            );

            foreach (var item in order.OrderItens)
            {
                _context.Connection.Execute(
                    "spSaveOrderItem",
                    new{
                        Id = item.Id,
                        OrderId = order.Id,
                        ProductId = item.Product.Id,
                        Quantity = item.Quantity,
                        Price = item.Price
                    },
                    commandType:CommandType.StoredProcedure
                );
            }
        }
    }
}
using System;

namespace Store.Domain.StoreContext.Queries
{
    public class ListCustomerOrdersQueryResult
    {
        public ListCustomerOrdersQueryResult()
        {
            
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string NumberOrder { get; private set; }
        public decimal Total { get; private set; }
    }
}
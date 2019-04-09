using System;

namespace Store.Domain.StoreContext.Queries
{
    public class ListCustomerOrdersQueryResult
    {
        public ListCustomerOrdersQueryResult(Guid iD, string name, string document, string email, string number, decimal total)
        {
            ID = iD;
            Name = name;
            Document = document;
            Email = email;
            Number = number;
            Total = total;
        }

        public Guid ID { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Number { get; private set; }
        public decimal Total { get; private set; }
    }
}
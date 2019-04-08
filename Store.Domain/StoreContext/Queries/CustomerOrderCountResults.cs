using System;

namespace Store.Domain.StoreContext.Queries
{
    public class CustomerOrderCountResults
    {
        public CustomerOrderCountResults(Guid id, string name, string document, int orders)
        {
            Id = id;
            Name = name;
            Document = document;
            Orders = orders;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public int Orders { get; private set; }
    }
}
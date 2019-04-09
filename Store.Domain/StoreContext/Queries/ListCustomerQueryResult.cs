using System;

namespace Store.Domain.StoreContext.Queries
{
    public class ListCustomerQueryResult
    {
        public ListCustomerQueryResult(Guid id, string name, string document, string email)
        {
            Id = id;
            Name = name;
            Document = document;
            Email = email;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
    }
}
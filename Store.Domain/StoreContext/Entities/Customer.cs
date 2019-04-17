using System.Collections;
using System.Collections.Generic;
using FluentValidator;
using Store.Domain.StoreContext.ValueObjects;
using Store.Shared.Entities;

namespace Store.Domain.StoreContext.Entities
{

    public class Customer : Entity
    {
        private readonly ICollection<Address> _addresses;
        public Customer(Name name, Document document, Email email, string phone)
        {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            _addresses = new List<Address>();
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public IEnumerable<Address> Addresses { get { return _addresses; } }

        public void AddAddress(Address address)
        {
            //valida o endereco
            AddNotifications(address.Notifications);
            _addresses.Add(address);
        }
    }
}
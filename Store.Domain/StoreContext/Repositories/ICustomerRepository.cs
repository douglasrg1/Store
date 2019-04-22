using System;
using System.Collections;
using System.Collections.Generic;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Queries;

namespace Store.Domain.StoreContext.Repositories{

    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);
        void Update(Customer customer);
        void Remove(Customer customer);
        CustomerOrderCountResults GetCustomerOrders(string document);
        IEnumerable<ListCustomerQueryResult> Get();
        CustomerQueryResult GetById(Guid id);
        IEnumerable <ListCustomerOrdersQueryResult> GetOrders( Guid id);
        IEnumerable <ListCustomerAdresses> GetAddresses( Guid id);
        void RemoveAddressesCustomer(Guid customerId);
    }
}
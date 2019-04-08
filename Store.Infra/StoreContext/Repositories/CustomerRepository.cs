using System.Data;
using System.Linq;
using Dapper;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Queries;
using Store.Domain.StoreContext.Repositories;
using Store.Infra.StoreContext.DataContext;

namespace Store.Infra.Repository
{

    public class CustomerRepository : ICustomerRepository
    {
        private readonly StoreDataContext _context;
        public CustomerRepository(StoreDataContext context)
        {
            _context = context;
        }
        public bool CheckDocument(string document)
        {
            return _context.Connection
            .Query<bool>(
                "spCheckDocument", new { Document = document },
                commandType: CommandType.StoredProcedure)
            .FirstOrDefault();

        }

        public bool CheckEmail(string email)
        {
            return _context.Connection
            .Query<bool>(
                "spCheckEmail", new { Email = email },
                commandType: CommandType.StoredProcedure)
            .FirstOrDefault();
        }

        public CustomerOrderCountResults GetCustomerOrders(string document)
        {
            return _context.Connection
            .Query<CustomerOrderCountResults>(
                "spGetCustomerOrderCount", new { Document = document },
                commandType: CommandType.StoredProcedure)
            .FirstOrDefault();
        }

        public void Remove(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public void Save(Customer customer)
        {
            _context.Connection.Execute(
                "spSaveCustomer",
                new
                {
                    Id = customer.Id,
                    FirstName = customer.Name.FirstName,
                    LastName = customer.Name.LastName,
                    Document = customer.Document.Number,
                    Email = customer.Email.Address,
                    Phone = customer.Phone
                },
                commandType: CommandType.StoredProcedure
            );

            foreach (var Address in customer.Addresses)
            {
                _context.Connection.Execute(
                    "spSaveAddress",
                    new{
                        Id = Address.Id,
                        CustomerId = customer.Id,
                        Number = Address.Number,
                        Complement = Address.Complement,
                        District = Address.District,
                        City = Address.City,
                        State = Address.State,
                        Country = Address.Country,
                        ZipCode = Address.ZipCode,
                        Type = Address.AddressType
                    },commandType: CommandType.StoredProcedure
                );
            }
        }

        public void Update(Customer customer)
        {
            throw new System.NotImplementedException();
        }
    }
}
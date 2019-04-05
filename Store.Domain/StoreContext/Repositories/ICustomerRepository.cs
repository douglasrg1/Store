using Store.Domain.StoreContext.Entities;

namespace Store.Domain.StoreContext.Repositories{

    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);
        void Update(Customer customer);
        void Remove(Customer customer);
    }
}
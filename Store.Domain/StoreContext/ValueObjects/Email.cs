
using FluentValidator;
using FluentValidator.Validation;

namespace Store.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;
            AddNotifications(new ValidationContract()
                .Requires()
                .IsEmail(address,"E-mail","O endereço de E-Mail não é valido")
            );
        }

        public string Address { get; private set; }
        public override string ToString()
        {
            return Address;
        }
    }
}
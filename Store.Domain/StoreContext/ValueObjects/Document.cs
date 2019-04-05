
using FluentValidator;
using FluentValidator.Validation;

namespace Store.Domain.StoreContext.ValueObjects
{
    public class Document : Notifiable
    {
        public Document(string number)
        {
            Number = number;
            
            AddNotifications(new ValidationContract()
                .Requires()
                .IsTrue(number.Length == 11,"Document","O numero de documento informado não é valido")
            );
        }

        public string Number { get; private set; }

        public override string ToString()
        {
            return Number;
        }
    }
}
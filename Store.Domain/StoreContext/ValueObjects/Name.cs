
using FluentValidator;
using FluentValidator.Validation;

namespace Store.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(firstName,3,"FirstName","O Campo FirstName deve conter no minimo 3 caracteres")
                .HasMaxLen(firstName,30,"FirstName","O campo nome deve conter no máximo 30 caracteres")
                .HasMinLen(lastName,3,"lastName","O Campo lastName deve conter no minimo 3 caracteres")
                .HasMaxLen(lastName,30,"lastName","O campo lastName deve conter no maximo 30 caracteres")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
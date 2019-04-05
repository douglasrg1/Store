using Store.Shared.Command;

namespace Store.Domain.StoreContext.Commands.CustomerCommand.Inputs
{

    public class CreateCustomerCommand : ICommand
    {
        public CreateCustomerCommand(string firstName, string lastName, string document, string email, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            Phone = phone;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
    }
}
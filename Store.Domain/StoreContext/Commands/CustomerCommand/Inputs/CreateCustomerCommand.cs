using System.Collections.Generic;
using Store.Domain.StoreContext.Entities;
using Store.Shared.Command;

namespace Store.Domain.StoreContext.Commands.CustomerCommand.Inputs
{

    public class CreateCustomerCommand : ICommand
    {
        private readonly ICollection<AddAddressCommand> _addresses;
        public CreateCustomerCommand(string firstName, string lastName, string document, string email, string phone,IList<AddAddressCommand> addresses)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            Phone = phone;
            _addresses = addresses;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public IEnumerable<AddAddressCommand> Addresses{get{return _addresses;}}
    }
}
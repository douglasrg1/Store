using System;
using Store.Domain.StoreContext.Enums;
using Store.Shared.Command;

namespace Store.Domain.StoreContext.Commands.CustomerCommand.Inputs
{

    public class AddAddressCommand : ICommand
    {
        public Guid Id { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public EAddressType AddressType { get; private set; }
    }
}
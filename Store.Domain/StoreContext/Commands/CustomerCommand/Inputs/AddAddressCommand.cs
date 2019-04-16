using System;
using Store.Domain.StoreContext.Enums;
using Store.Shared.Command;

namespace Store.Domain.StoreContext.Commands.CustomerCommand.Inputs
{

    public class AddAddressCommand : ICommand
    {
        public AddAddressCommand(string street, string number, string complement, string district, string city, string state, string country, string zipCode, EAddressType addressType)
        {
            Street = street;
            Number = number;
            Complement = complement;
            District = district;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            AddressType = addressType;
        }

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
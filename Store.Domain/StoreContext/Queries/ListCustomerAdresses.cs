using System;
using Store.Domain.StoreContext.Enums;

namespace Store.Domain.StoreContext.Queries
{
    public class ListCustomerAdresses
    {
        public ListCustomerAdresses()
        {
            
        }

        public ListCustomerAdresses(string street, string number, string complement, string district, string city, string state, string country, string zipCode, EAddressType addressType)
        {
            Street = street;
            NumberAddress = number;
            Complement = complement;
            District = district;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            AddressType = addressType;
        }

        public string Street { get; private set; }
        public string NumberAddress { get; private set; }
        public string Complement { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public EAddressType AddressType { get; private set; }
    }
}
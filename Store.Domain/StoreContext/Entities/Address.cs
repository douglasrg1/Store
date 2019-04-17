
using System;
using FluentValidator;
using FluentValidator.Validation;
using Store.Domain.StoreContext.Enums;
using Store.Shared.Entities;

namespace Store.Domain.StoreContext.Entities
{
    public class Address : Entity
    {
        public Address(string street, string number, string complement, string district, string city, string state, string country, string zipCode, EAddressType addressType)
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

            AddNotifications(new ValidationContract()
                .Requires()
                .IsFalse(number.Length == 0,"Address","O numero de endereco informado não é valído")
                .IsNotNullOrEmpty(street,"Address","O campo rua do endereço informado não é valído")
                .IsNotNullOrEmpty(Complement,"Complement","O campo Complemento do endereço informado não é valído")
                .IsNotNullOrEmpty(District,"District","O campo bairro do endereço informado não é valído")
                .IsNotNullOrEmpty(City,"City","O campo cidade do endereço informado não é valído")
                .IsNotNullOrEmpty(State,"State","O campo estado do endereço informado não é valído")
                .IsNotNullOrEmpty(Country,"Country","O campo pais do endereço informado não é valído")
                .IsNotNullOrEmpty(ZipCode,"ZipCode","O campo Código Postal do endereço informado não é valído")

            );
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
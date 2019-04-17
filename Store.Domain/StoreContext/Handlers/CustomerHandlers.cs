using System;
using System.Linq;
using FluentValidator;
using Store.Domain.StoreContext.Commands.CustomerCommand.Inputs;
using Store.Domain.StoreContext.Commands.CustomerCommand.Outputs;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Repositories;
using Store.Domain.StoreContext.Services;
using Store.Domain.StoreContext.ValueObjects;
using Store.Shared.Command;

namespace Store.Domain.StoreContext.Handlers
{

    public class CustomerHandlers : Notifiable,
     ICommandHandler<CreateCustomerCommand>,
     ICommandHandler<UpdateCustomerCommand>
    {

        private readonly ICustomerRepository _customer;
        private readonly IEmailService _email;

        public CustomerHandlers(ICustomerRepository customer, IEmailService email)
        {
            _customer = customer;
            _email = email;
        }
        public ICommandResult Handle(CreateCustomerCommand Command)
        {
            //verificar se o email já existe no bd
            if (_customer.CheckDocument(Command.Document))
                AddNotification("Document", "Este documento já está cadastrado");
            //verificar se o email já existe no bd
            if (_customer.CheckEmail(Command.Email))
                AddNotification("Email", "Este email já está cadastrado em nossa base de dados");
            //criar vos
            var name = new Name(Command.FirstName, Command.LastName);
            var document = new Document(Command.Document);
            var email = new Email(Command.Email);

            // criar entidade
            var customer = new Customer(name, document, email, Command.Phone);
            if (Command.Addresses.Count() > 0)
            {
                foreach (var item in Command.Addresses)
                {
                    var address = new Address(item.Street, item.Number, item.Complement, item.District, item.City, item.State, item.Country, item.ZipCode, item.AddressType);
                    customer.AddAddress(address);
                }
            }


            //validar entidades vos
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid)
                return new CustomerResult(false, "Erro nos campos Iformados", Notifications); ;

            //persistir o cliente
            _customer.Save(customer);

            //enviar email boas vindas
            _email.Send(Command.Email, "teste@teste", "Bem vindo", "mensagem de boas vindas");

            // retornar o resultado

            return new CustomerResult(true, "Cadastro realizado com sucesso", new { Name = customer.Name.ToString(), Id = customer.Id, Email = customer.Email.Address });
        }

        public ICommandResult Handle(UpdateCustomerCommand Command)
        {
            //criar vos
            var name = new Name(Command.FirstName, Command.LastName);
            var document = new Document(Command.Document);
            var email = new Email(Command.Email);

            // criar entidade
            var customer = new Customer(name, document, email, Command.Phone);
            if (Command.Addresses.Count() > 0)
            {
                foreach (var item in Command.Addresses)
                {
                    var address = new Address(item.Street, item.Number, item.Complement, item.District, item.City, item.State, item.Country, item.ZipCode, item.AddressType);
                    customer.AddAddress(address);
                }
            }


            //validar entidades vos
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid)
                return new CustomerResult(false, "Erro nos campos Iformados", Notifications); ;

            //persistir o cliente
            _customer.Save(customer);

            //enviar email boas vindas
            _email.Send(Command.Email, "teste@teste", "Bem vindo", "mensagem de boas vindas");

            // retornar o resultado

            return new CustomerResult(true, "Cadastro realizado com sucesso", new { Name = customer.Name.ToString(), Id = customer.Id, Email = customer.Email.Address });
        }
    }
}
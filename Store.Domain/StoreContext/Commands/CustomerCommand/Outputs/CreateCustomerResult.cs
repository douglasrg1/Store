using System;
using Store.Shared.Command;

namespace Store.Domain.StoreContext.Commands.CustomerCommand.Outputs
{

    public class CreateCustomerResult : ICommandResult
    {
        public CreateCustomerResult()
        {
            
        }
        public CreateCustomerResult(Guid id, string name, string document)
        {
            Id = id;
            Document = document;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
    }
}
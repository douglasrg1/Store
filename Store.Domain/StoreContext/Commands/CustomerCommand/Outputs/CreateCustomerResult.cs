using System;
using Store.Shared.Command;

namespace Store.Domain.StoreContext.Commands.CustomerCommand.Outputs
{

    public class CreateCustomerResult : ICommandResult
    {
        public CreateCustomerResult(bool success, string message, object data)
        {
            Success = success;
            this.message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string message { get; set; }
        public object Data { get; set; }
    }
}
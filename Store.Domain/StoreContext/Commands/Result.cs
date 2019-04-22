using System;
using Store.Shared.Command;

namespace Store.Domain.StoreContext.Commands
{

    public class Result : ICommandResult
    {
        public Result(bool success, string message, object data)
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
namespace Store.Shared.Command
{

    public interface ICommandResult
    {
        bool Success { get; set; }
        string message { get; set; }
        object Data { get; set; }
    }
}
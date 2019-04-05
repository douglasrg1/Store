namespace Store.Shared.Command{

    public interface ICommandHandler<t> where t:ICommand
    {
        ICommandResult Handle(t Command);
    }
}
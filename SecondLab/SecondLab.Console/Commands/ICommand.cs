namespace SecondLab.Console.Commands;

public interface ICommand
{
    CommandResult Execute();
    string Description { get; }
}

public class CommandResult
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }
}
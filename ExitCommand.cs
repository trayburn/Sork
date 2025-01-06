namespace Sork;

public class ExitCommand : ICommand
{
    public bool Handles(string userInput) => userInput == "exit";
    public CommandResult Execute() => new CommandResult { RequestExit = true, IsHandled = true };
}
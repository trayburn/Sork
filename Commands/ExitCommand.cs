namespace Sork.Commands;

public class ExitCommand : ICommand
{  
    private readonly UserInputOutput io;
    public ExitCommand(UserInputOutput io)
    {
        this.io = io;
    }
    public bool Handles(string userInput) => userInput == "exit";
    public CommandResult Execute() => new CommandResult { RequestExit = true, IsHandled = true };
}
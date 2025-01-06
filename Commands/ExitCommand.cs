namespace Sork.Commands;

public class ExitCommand : BaseCommand
{  
    private readonly UserInputOutput io;
    public ExitCommand(UserInputOutput io)
    {
        this.io = io;
    }
    public override bool Handles(string userInput) => GetCommandFromInput(userInput) == "exit";
    public override CommandResult Execute() => new CommandResult { RequestExit = true, IsHandled = true };
}
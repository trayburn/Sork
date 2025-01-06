namespace Sork.Commands;
public class DanceCommand : ICommand
{
    private readonly UserInputOutput io;
    public DanceCommand(UserInputOutput io)
    {
        this.io = io;
    }
    public bool Handles(string userInput) => userInput == "dance";
    public CommandResult Execute() 
    { 
        io.WriteMessageLine("You dance!"); 
        return new CommandResult { RequestExit = false, IsHandled = true }; 
    }
}

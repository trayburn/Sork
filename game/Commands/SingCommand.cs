namespace Sork.Commands;
using Sork.World;
public class SingCommand : BaseCommand
{
    private readonly IUserInputOutput io;
    public SingCommand(IUserInputOutput io)
    {
        this.io = io;
    }
    public override bool Handles(string userInput) => GetCommandFromInput(userInput) == "sing";
    public override CommandResult Execute(string userInput, Player player)
    {
        io.WriteNoun("You");
        io.WriteMessageLine(" sing!");
        return new CommandResult { RequestExit = false, IsHandled = true };
    }
}
namespace Sork.Commands;
using Sork.World;
public class SingCommand : BaseCommand
{
    private readonly UserInputOutput io;
    public SingCommand(UserInputOutput io)
    {
        this.io = io;
    }
    public override bool Handles(string userInput) => GetCommandFromInput(userInput) == "sing";
    public override CommandResult Execute(string userInput, GameState gameState)
    {
        io.WriteNoun("You");
        io.WriteMessageLine(" sing!");
        return new CommandResult { RequestExit = false, IsHandled = true };
    }
}
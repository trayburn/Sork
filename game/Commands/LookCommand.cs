using Sork.World;

namespace Sork.Commands;

public class LookCommand : BaseCommand
{
    private readonly IUserInputOutput io;
    public LookCommand(IUserInputOutput io)
    {
        this.io = io;
    }

    public override bool Handles(string userInput)
    {
        return GetCommandFromInput(userInput) == "look";
    }

    public override CommandResult Execute(string userInput, GameState gameState)
    {
        io.WriteNoun(gameState.Player.Location.Name);
        io.WriteMessageLine("");
        io.WriteMessageLine(gameState.Player.Location.Description);
        io.WriteMessageLine("");
        io.WriteMessageLine("Exits:");
        foreach (var exit in gameState.Player.Location.Exits)
        {
            io.WriteMessageLine($"{exit.Key} - {exit.Value.Description}");
        }
        io.WriteMessageLine("");
        io.WriteMessageLine("Inventory:");
        foreach (var item in gameState.Player.Location.Inventory)
        {
            io.WriteMessageLine($"{item.Name} - {item.Description}");
        }


        return new CommandResult { RequestExit = false, IsHandled = true };
    }
}

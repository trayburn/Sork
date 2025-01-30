using Sork.World;

namespace Sork.Commands;

public class LookCommand : BaseCommand
{
    private readonly IUserInputOutput io;
    private readonly GameState gameState;
    public LookCommand(IUserInputOutput io, GameState gameState)
    {
        this.io = io;
        this.gameState = gameState;
    }

    public override bool Handles(string userInput)
    {
        return GetCommandFromInput(userInput) == "look";
    }

    public override CommandResult Execute(string userInput, Player player)
    {
        io.WriteNoun(player.Location.Name);
        io.WriteMessageLine("");
        io.WriteMessageLine(player.Location.Description);
        io.WriteMessageLine("");
        io.WriteMessageLine("Exits:");
        foreach (var exit in player.Location.Exits)
        {
            io.WriteMessageLine($"{exit.Key} - {exit.Value.Description}");
        }
        io.WriteMessageLine("");
        io.WriteMessageLine("Inventory:");
        foreach (var item in player.Location.Inventory)
        {
            io.WriteMessageLine($"{item.Name} - {item.Description}");
        }
        io.WriteMessageLine("");
        io.WriteMessageLine("Players:");
        foreach (var p in player.Location.Players)
        {
            io.WriteMessageLine($"{p.Name}");
        }

        return new CommandResult { RequestExit = false, IsHandled = true };
    }
}

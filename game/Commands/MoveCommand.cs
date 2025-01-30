namespace Sork.Commands;
using Sork.World;
public class MoveCommand : BaseCommand
{
    private readonly IUserInputOutput io;
    public MoveCommand(IUserInputOutput io)
    {
        this.io = io;
    }
    public override bool Handles(string userInput)
    {
        return GetCommandFromInput(userInput) == "move" && GetParametersFromInput(userInput).Length == 1;
    }
    public override CommandResult Execute(string userInput, Player player)
    {
        var direction = GetParametersFromInput(userInput)[0].ToLower();
        player.Location.MovePlayer(player, direction);
        io.WriteMessageLine($"You move to {player.Location.Name}.");
        return new CommandResult { RequestExit = false, IsHandled = true };
    }
}
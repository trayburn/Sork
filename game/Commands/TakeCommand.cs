namespace Sork.Commands;
using Sork.World;

public class TakeCommand : BaseCommand
{
    private readonly IUserInputOutput io;
    public TakeCommand(IUserInputOutput io)
    {
        this.io = io;
    }

    public override bool Handles(string userInput)
    {
        return GetCommandFromInput(userInput) == "take";
    }

    public override CommandResult Execute(string userInput, GameState gameState)
    {
        var parameters = GetParametersFromInput(userInput);
        if (parameters.Length == 0)
        {
            io.WriteMessageLine("You must specify an item to take.");
            return new CommandResult() { IsHandled = false, RequestExit = false};
        }

        var item = gameState.Player.Location.Inventory.FirstOrDefault(item => item.Name.ToLower() == parameters[0].ToLower());
        if (item == null)
        {
            io.WriteMessageLine("You don't see that item here.");
            return new CommandResult() { IsHandled = false, RequestExit = false};
        }

        gameState.Player.Inventory.Add(item);
        gameState.Player.Location.Inventory.Remove(item);

        return new CommandResult() { IsHandled = true, RequestExit = false};
    }
}

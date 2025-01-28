namespace Sork.Commands;
using Sork.World;
public class LaughCommand : BaseCommand
{
    private readonly IUserInputOutput io;
    public LaughCommand(IUserInputOutput io)
    {
        this.io = io;
    }
    public override bool Handles(string userInput)
    {
        return GetCommandFromInput(userInput) == "lol";
    }

    public override CommandResult Execute(string userInput, Player player)
    {
        io.WriteNoun("You");
        io.WriteMessageLine(" laugh out loud!");

        return new CommandResult { RequestExit = false, IsHandled = true };
    }
}
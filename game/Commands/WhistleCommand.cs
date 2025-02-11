using Sork.World;

namespace Sork.Commands;

public class WhistleCommand : BaseCommand
{
    private readonly IUserInputOutput io;
    public WhistleCommand(IUserInputOutput io)
    {
        this.io = io;
    }
    public override bool Handles(string userInput, Player player) => GetCommandFromInput(userInput) == "whistle";
    public override CommandResult Execute(string userInput, Player player)
    {
        io.WriteNoun("You");
        io.WriteMessageLine(" whistle!");
        io.SpeakNoun(player.Name, player.Location);
        io.SpeakMessageLine(" whistles!", player.Location);
        return new CommandResult { RequestExit = false, IsHandled = true };
    }
}
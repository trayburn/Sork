namespace Sork.Commands;
using Sork.World;
public class LaughCommand : BaseCommand
{
    private readonly IUserInputOutput io;
    public LaughCommand(IUserInputOutput io)
    {
        this.io = io;
    }
    public override bool Handles(string userInput, Player player)
    {
        return GetCommandFromInput(userInput) == "lol";
    }

    public override CommandResult Execute(string userInput, Player player)
    {
        io.WriteNoun("You");
        io.WriteMessageLine(" laugh out loud!");
        io.SpeakNoun(player.Name, player.Location);
        io.SpeakMessageLine(" laughs out loud!", player.Location);
        return new CommandResult { RequestExit = false, IsHandled = true };
    }
}
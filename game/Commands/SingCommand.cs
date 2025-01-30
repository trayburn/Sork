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
        io.SpeakNoun(player.Name, player.Location);
        io.SpeakMessageLine(" sings!", player.Location);
        return new CommandResult { RequestExit = false, IsHandled = true };
    }
}
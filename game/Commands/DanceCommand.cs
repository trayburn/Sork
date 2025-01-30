namespace Sork.Commands;
using Sork.World;
public class DanceCommand : BaseCommand
{
    private readonly IUserInputOutput io;
    public DanceCommand(IUserInputOutput io)
    {
        this.io = io;
    }
    public override bool Handles(string userInput) {
        var paramsLength = GetParametersFromInput(userInput).Length;
        return GetCommandFromInput(userInput) == "dance" && (paramsLength == 0 || paramsLength == 1);
    }
    public override CommandResult Execute(string userInput, Player player) 
    { 
        var parameters = GetParametersFromInput(userInput);
        if (parameters.Length == 0) {
            io.WriteNoun("You");
            io.WriteMessageLine(" dance!"); 
            io.SpeakNoun(player.Name, player.Location);
            io.SpeakMessageLine(" dances!", player.Location);
        } else {
            io.WriteNoun("You");
            io.WriteMessage(" dance with ");
            io.WriteNoun(parameters[0]);
            io.WriteMessageLine("!"); 
            io.SpeakNoun(player.Name, player.Location);
            io.SpeakMessage(" dances with ", player.Location);
            io.SpeakNoun(parameters[0], player.Location);
            io.SpeakMessageLine("!", player.Location);
        }
        return new CommandResult { RequestExit = false, IsHandled = true }; 
    }
}

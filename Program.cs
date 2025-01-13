using Sork.Commands;
using Sork.World;

namespace Sork;
public class Program
{
    public static void Main(string[] args)
    {
        UserInputOutput io = new UserInputOutput();

        var gameState = GameState.Create(io);

        ICommand lol = new LaughCommand(io);
        ICommand exit = new ExitCommand(io);
        ICommand dance = new DanceCommand(io);
        ICommand sing = new SingCommand(io);
        ICommand whistle = new WhistleCommand(io);
        ICommand move = new MoveCommand(io);
        ICommand look = new LookCommand(io);
        List<ICommand> commands = new List<ICommand> { lol, exit, dance, sing, whistle, move, look };

        do
        {
            io.WritePrompt(" > ");
            string input = io.ReadInput();

            var result = new CommandResult { RequestExit = false, IsHandled = false };
            var handled = false;
            foreach (var command in commands)
            {
                if (command.Handles(input)) 
                {
                    handled = true;
                    result = command.Execute(input, gameState);
                    if (result.RequestExit) { break; } 
                }
            }
            if (!handled) { io.WriteMessageLine("Unknown command"); }
            if (result.RequestExit) { break; }

        } while (true);
    }
}


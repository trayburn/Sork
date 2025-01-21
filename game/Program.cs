using Microsoft.Extensions.DependencyInjection;
using Sork.Commands;
using Sork.World;
using System.Net;
using System.Net.Sockets;

namespace Sork;
public class Program
{
    public static async Task Main(string[] args)
    {
        var networkGame = new NetworkGame();
        networkGame.ClientConnected += (sender, e) => RunGame(networkGame, e.Client);
        await networkGame.StartListening();
    }

    public static void RunGame(NetworkGame networkGame, TcpClient client)
    {
        var services = new ServiceCollection();
        services.AddSingleton<IUserInputOutput, NetworkInputOutput>(sp => new NetworkInputOutput(client));
        services.AddSingleton<GameState>(sp => GameState.Create(sp.GetRequiredService<IUserInputOutput>()));
        var commandTypes = typeof(ICommand).Assembly.GetTypes()
            .Where(t => typeof(ICommand).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

        foreach (var commandType in commandTypes)
        {
            services.AddSingleton(typeof(ICommand), commandType);
        }
        var provider = services.BuildServiceProvider();

        var gameState = provider.GetRequiredService<GameState>();
        var commands = provider.GetServices<ICommand>().ToList();
        var io = provider.GetRequiredService<IUserInputOutput>();

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


using Microsoft.Extensions.DependencyInjection;
using Sork.Commands;
using Sork.Network;
using Sork.World;
using System.Net;
using System.Net.Sockets;

namespace Sork;
public class Program
{
    public static async Task Main(string[] args)
    {
        var networkGame = new NetworkGame();
        var gameState = GameState.Create();
        networkGame.ClientConnected += (sender, e) => {
            Task.Run(() => RunGame(networkGame, e.Client, gameState));
        };
        await networkGame.StartListening();
    }

    public static void RunGame(NetworkGame networkGame, TcpClient client, GameState gameState)
    {
        var services = new ServiceCollection();
        services.AddSingleton<IUserInputOutput, NetworkInputOutput>(sp => new NetworkInputOutput(client));
        services.AddSingleton<GameState>(sp => gameState);
        var commandTypes = typeof(ICommand).Assembly.GetTypes()
            .Where(t => typeof(ICommand).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

        foreach (var commandType in commandTypes)
        {
            services.AddSingleton(typeof(ICommand), commandType);
        }
        var provider = services.BuildServiceProvider();

        var commands = provider.GetServices<ICommand>().ToList();
        var io = provider.GetRequiredService<IUserInputOutput>();

        io.WritePrompt("What is your name? ");
        string name = io.ReadInput();
        var player = new Player { Name = name, Location = gameState.RootRoom, IO = io };
        gameState.Players.Add(player);

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
                    result = command.Execute(input, player);
                    if (result.RequestExit) { break; } 
                }
            }
            if (!handled) { io.WriteMessageLine("Unknown command"); }
            if (result.RequestExit) { break; }

        } while (true);
    }
}


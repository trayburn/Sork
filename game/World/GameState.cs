namespace Sork.World;

public class GameState
{
    public required Player Player { get; set; }
    public required Room RootRoom { get; set; }

    public static GameState Create(IUserInputOutput io)
    {
        var tavern = new Room { Name = "Tavern", Description = "You are in the Tavern." };
        var dungeon = new Room { Name = "Dungeon", Description = "You are in the dungeon." };

        tavern.Exits.Add("down", dungeon);
        dungeon.Exits.Add("up", tavern);
        
        io.WritePrompt("What is your name?");
        string name = io.ReadInput();

        var player = new Player { Name = name, Location = tavern };
        return new GameState { Player = player, RootRoom = tavern };
    }
}


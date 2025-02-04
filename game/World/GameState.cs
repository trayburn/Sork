namespace Sork.World;

public class GameState
{
    public List<Player> Players { get; set; } = [];
    public required Room RootRoom { get; set; }

    public static GameState Create()
    {
        var tavern = new Room { Name = "Tavern", Description = "You are in the Tavern." };
        var dungeon = new Room { Name = "Dungeon", Description = "You are in the dungeon." };

        var sword = new Item { Name = "Sword", Description = "A sword." };
        var mug = new Item { Name = "Mug", Description = "A mug." };

        tavern.Inventory.Add(mug);
        tavern.Inventory.Add(sword);

        tavern.Exits.Add(new Exit 
        { 
            Name = "Dungeon", 
            Destination = dungeon, 
            Aliases = { "d", "down", "do", "dow" } ,
            Description="A path to the Dungeon"
        });
        dungeon.Exits.Add(new Exit 
        { 
            Name = "Tavern Door", 
            Destination = tavern, 
            Aliases = { "u", "up", "ladder" } ,
            Description="A door to the Tavern above."
        });
        
        return new GameState { RootRoom = tavern };
    }
}


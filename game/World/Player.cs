namespace Sork.World;

public class Player
{
    public required string Name { get; set; }
    public required Room Location { get; set; }

    public List<Item> Inventory { get; } = new();
}


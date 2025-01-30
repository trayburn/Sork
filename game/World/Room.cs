namespace Sork.World;

public class Room 
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public Dictionary<string, Room> Exits { get; } = new Dictionary<string, Room>();
    public List<Item> Inventory { get; } = new();
    public List<Player> Players { get; } = new();

    public void MovePlayer(Player player, string direction)
    {
        var exit = Exits[direction];
        Players.Remove(player);
        player.Location = exit;
    }
}

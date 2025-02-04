namespace Sork.World;

public class Room 
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public List<Exit> Exits { get; } = new();
    public List<Item> Inventory { get; } = new();
    public List<Player> Players { get; } = new();

    public Exit? GetExit(string direction)
    {
        return Exits.FirstOrDefault(e => e.Name.ToLower() == direction.ToLower() || e.Aliases.Contains(direction.ToLower()));
    }

    public bool MovePlayer(Player player, string direction)
    {
        var exit = GetExit(direction);
        if (exit == null)
        {
            return false;
        }
        Players.Remove(player);
        player.Location = exit.Destination;
        return true;
    }

}

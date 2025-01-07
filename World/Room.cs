namespace Sork.World;

public class Room 
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public Dictionary<string, Room> Exits { get; } = new Dictionary<string, Room>();
}

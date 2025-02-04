namespace Sork.World;

public class Exit
{
    public required string Name { get; set; }
    public List<string> Aliases { get; set; } = new();
    public required Room Destination { get; set; }
    public required string Description { get; set; }
}

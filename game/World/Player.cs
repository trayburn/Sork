namespace Sork.World;

public class Player
{
    private Room location;

    public required string Name { get; set; }
    public required Room Location 
    {
        get => location;
        set
        {
            location = value;
            location.Players.Add(this);
        }
    }
    public required IUserInputOutput IO { get; set; }

    public List<Item> Inventory { get; } = new();
}


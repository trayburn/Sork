namespace Sork;
using Sork.World;
public interface ICommand
{
    bool Handles(string userInput);
    CommandResult Execute(string userInput, Player player);
}
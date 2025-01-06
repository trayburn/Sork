namespace Sork.Commands;
public abstract class BaseCommand : ICommand
{
    public abstract bool Handles(string userInput);
    public abstract CommandResult Execute();

    public string GetCommandFromInput(string userInput)
    {
        return userInput.Split(' ')[0].ToLower();
    }
}
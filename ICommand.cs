public interface ICommand
{
    bool Handles(string userInput);
    CommandResult Execute();
}
namespace Sork;

public interface IUserInputOutput
{
    void WritePrompt(string prompt);
    void WriteMessage(string message);
    void WriteNoun(string noun);
    void WriteMessageLine(string message);
    string ReadInput();
    string ReadKey();
}

public class UserInputOutput : IUserInputOutput
{
    public void WritePrompt(string prompt) 
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(prompt);
        Console.ResetColor();
    }
    public void WriteMessage(string message) 
    {
        Console.Write(message);
    }
    public void WriteNoun(string noun) 
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(noun);
        Console.ResetColor();
    }
    public void WriteMessageLine(string message) 
    {
        Console.WriteLine(message);
    }

    public string ReadInput() 
    {
        return (Console.ReadLine() ?? "").Trim();
    }
    public string ReadKey() 
    {
        return Console.ReadKey().KeyChar.ToString();
    }

}



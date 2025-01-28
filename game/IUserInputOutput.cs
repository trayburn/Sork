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

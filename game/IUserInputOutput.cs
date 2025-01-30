using Sork.World;

namespace Sork;

public interface IUserInputOutput
{
    void WritePrompt(string prompt);
    void WriteMessage(string message);
    void WriteNoun(string noun);
    void WriteMessageLine(string message);

    void SpeakMessage(string message, Room room);
    void SpeakNoun(string noun, Room room);
    void SpeakMessageLine(string message, Room room);

    string ReadInput();
    string ReadKey();
}

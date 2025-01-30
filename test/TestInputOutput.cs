using Sork;
using Sork.World;

public class TestInputOutput : IUserInputOutput
{
    public List<string> Outputs {get;set;} = [];
    public Dictionary<Room, List<string>> SpeakOutputs {get;set;} = [];

    public string ReadInput()
    {
        return "John";
    }

    public string ReadKey()
    {
        return "";
    }

    public void SpeakMessage(string message, Room room)
    {
        if (!SpeakOutputs.ContainsKey(room))
            SpeakOutputs[room] = [];
        SpeakOutputs[room].Add(message);
    }

    public void SpeakMessageLine(string message, Room room)
    {
        if (!SpeakOutputs.ContainsKey(room))
            SpeakOutputs[room] = [];
        SpeakOutputs[room].Add(message);
    }

    public void SpeakNoun(string noun, Room room)
    {
        if (!SpeakOutputs.ContainsKey(room))
            SpeakOutputs[room] = [];
        SpeakOutputs[room].Add(noun);
    }

    public void WriteMessage(string message)
    {
        Outputs.Add(message);
    }

    public void WriteMessageLine(string message)
    {
        Outputs.Add(message);
    }

    public void WriteNoun(string noun)
    {
        Outputs.Add(noun);
    }

    public void WritePrompt(string prompt)
    {
    }
}
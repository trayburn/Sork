using Sork;

public class TestInputOutput : IUserInputOutput
{
    public List<string> Outputs {get;set;} = [];

    public string ReadInput()
    {
        return "John";
    }

    public string ReadKey()
    {
        throw new NotImplementedException();
    }

    public void WriteMessage(string message)
    {
        throw new NotImplementedException();
    }

    public void WriteMessageLine(string message)
    {
        Outputs.Add(message);
    }

    public void WriteNoun(string noun)
    {
        throw new NotImplementedException();
    }

    public void WritePrompt(string prompt)
    {
    }
}
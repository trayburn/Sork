using System.Net.Sockets;
using System.IO;

namespace Sork.Network;

public class NetworkInputOutput : IUserInputOutput
{
    private readonly TcpClient client;
    private readonly StreamReader reader;
    private readonly StreamWriter writer;

    public NetworkInputOutput(TcpClient client)
    {
        this.client = client;
        var stream = client.GetStream();
        reader = new StreamReader(stream);
        writer = new StreamWriter(stream);
        writer.AutoFlush = true;
    }

    public void WritePrompt(string prompt)
    {
        writer.Write(prompt);
    }

    public void WriteMessage(string message)
    {
        writer.Write(message);
    }

    public void WriteNoun(string noun)
    {
        writer.Write(noun);
    }

    public void WriteMessageLine(string message)
    {
        writer.WriteLine(message);
    }

    public string ReadInput()
    {
        return reader.ReadLine()?.Trim() ?? "";
    }

    public string ReadKey()
    {
        // Read a single character
        int charCode = reader.Read();
        return charCode >= 0 ? ((char)charCode).ToString() : "";
    }
}
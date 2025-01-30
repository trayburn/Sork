using System.Net.Sockets;
using System.IO;
using Sork.World;

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
        return reader.ReadLine()?.NetworkCleanup()?.Trim() ?? "";
    }

    public string ReadKey()
    {
        // Read a single character
        int charCode = reader.Read();
        return charCode >= 0 ? ((char)charCode).ToString() : "";
    }

    public void SpeakMessage(string message, Room room)
    {
        foreach (var player in room.Players)
        {
            if (player.IO == this)
                continue;
            player.IO.WriteMessage($"{message}");
        }
    }

    public void SpeakNoun(string noun, Room room)
    {
        foreach (var player in room.Players)
        {
            if (player.IO == this)
                continue;
            player.IO.WriteNoun($"{noun}");
        }
    }

    public void SpeakMessageLine(string message, Room room)
    {
        foreach (var player in room.Players)
        {
            if (player.IO == this)
                continue;
            player.IO.WriteMessageLine($"{message}");
        }
    }
}
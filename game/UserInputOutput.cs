namespace Sork;

using System.Net;
using System.Net.Sockets;

public class ClientConnectedEventArgs : EventArgs
{
    public TcpClient Client { get; }

    public ClientConnectedEventArgs(TcpClient client)
    {
        Client = client;
    }
}

public class NetworkGame
{
    
    public event EventHandler<ClientConnectedEventArgs>? ClientConnected;
    private TcpListener? listener;
    private const int Port = 1701;

    public async Task StartListening()
    {
        listener = new TcpListener(IPAddress.Any, Port);
        listener.Start();

        try
        {
            
            TcpClient client = await listener.AcceptTcpClientAsync();
            OnClientConnected(new ClientConnectedEventArgs(client));
        }
        catch (Exception)
        {
            // Handle exceptions
        }
    }

    protected virtual void OnClientConnected(ClientConnectedEventArgs e)
    {
        ClientConnected?.Invoke(this, e);
    }

    public void Stop()
    {
        listener?.Stop();
    }
}

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



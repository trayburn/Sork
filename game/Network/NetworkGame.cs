using System.Net;
using System.Net.Sockets;

namespace Sork.Network;

public class NetworkGame
{
    
    public event EventHandler<ClientConnectedEventArgs>? ClientConnected;
    private TcpListener? listener;
    private const int Port = 1701;

    public async Task StartListening()
    {
        listener = new TcpListener(IPAddress.Any, Port);
        listener.Start();

        while (true)
        {
            try
            {
                Console.WriteLine("Waiting for client connection...");
                TcpClient client = await listener.AcceptTcpClientAsync();
                OnClientConnected(new ClientConnectedEventArgs(client));
            }
            catch (Exception)
            {
                // Handle exceptions
            }
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
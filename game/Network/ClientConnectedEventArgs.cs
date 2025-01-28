using System;
using System.Net.Sockets;

namespace Sork.Network;

public class ClientConnectedEventArgs : EventArgs
{
    public TcpClient Client { get; }

    public ClientConnectedEventArgs(TcpClient client)
    {
        Client = client;
    }
}
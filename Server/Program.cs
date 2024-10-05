using System.Net.Sockets;
using System.Net;
using Server;

ServerService request = new ServerService();

Console.WriteLine("TCP Server ready to connect");

TcpListener listener = new TcpListener(IPAddress.Any, 7);

listener.Start();

while (true)
{
    TcpClient socket = listener.AcceptTcpClient();

    Task.Run(() => request.HandleClient(socket));
}

listener.Stop();
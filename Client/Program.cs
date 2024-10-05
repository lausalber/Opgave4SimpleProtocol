using System.Net.Sockets;

TcpClient clientSocket = new TcpClient("127.0.0.1", 7);
Console.WriteLine("Client is ready");

Stream ns = clientSocket.GetStream();
StreamReader reader = new StreamReader(ns);
StreamWriter writer = new StreamWriter(ns);
writer.AutoFlush = true;

string welcome = reader.ReadLine();
Console.WriteLine(welcome);

while (true)
{
    // server asks for method
    string message = reader.ReadLine();
    Console.WriteLine(message);

    // chooses which method to use and sends it to the server
    message = Console.ReadLine();
    writer.WriteLine(message);

    // server asks for numbers
    message = reader.ReadLine();
    Console.WriteLine(message);

    // two numbers sent to server
    message = Console.ReadLine();
    writer.WriteLine(message);

    // result sent from server
    string result = reader.ReadLine();
    Console.WriteLine(result);
}

ns.Close();
clientSocket.Close();

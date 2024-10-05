using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ServerService
    {
        public void HandleClient(TcpClient socket)
        {
            NetworkStream ns = socket.GetStream();
            StreamReader reader = new StreamReader(ns);
            StreamWriter writer = new StreamWriter(ns);

            writer.WriteLine("Welcome to the server!");
            writer.Flush();

            while (true)
            {
                writer.WriteLine("Please type add, subtract, or random (type close to exit):");
                writer.Flush();
                string message = reader.ReadLine();

                if (message.ToLower() == "close")
                {
                    break;
                }

                writer.WriteLine("Please enter two numbers separated by a space:");
                writer.Flush();
                string numbersMessage = reader.ReadLine();

                double? output = 0;

                if (message.ToLower() == "add")
                {
                    output = AddRequest(numbersMessage);
                    if (output == null)
                    {
                        writer.WriteLine("Invalid input, please try again");
                    }
                    else
                    {
                        writer.WriteLine(output);
                    }
                }
                else if (message.ToLower() == "subtract")
                {
                    output = SubtractRequest(numbersMessage);
                    if (output == null)
                    {
                        writer.WriteLine("Invalid input, please try again");
                    }
                    else
                    {
                        writer.WriteLine(output);
                    }
                }
                else if (message.ToLower() == "random")
                {
                    output = RandomRequest(numbersMessage);
                    if (output == null)
                    {
                        writer.WriteLine("Invalid input, please try again. Remember the first number can't be bigger than the second number.");
                    }
                    else
                    {
                        writer.WriteLine(output);
                    }
                }
                else
                {
                    writer.WriteLine("Invalid input. Please type add, subtract, or random (type close to exit):");
                }

                writer.Flush();
                Console.WriteLine("Client sent: " + message);
            }
            socket.Close();
        }

        public double? AddRequest(string request)
        {
            string[] stn = request.Split(" ");

            if (stn.Length != 2 || !double.TryParse(stn[0], out double x) || !double.TryParse(stn[1], out double y))
            {
                return null;
            }

            return x + y;
        }

        public double? SubtractRequest(string request)
        {
            string[] stn = request.Split(" ");

            if (stn.Length != 2 || !double.TryParse(stn[0], out double x) || !double.TryParse(stn[1], out double y))
            {
                return null;
            }

            return x - y;
        }

        public int? RandomRequest(string request)
        {
            string[] stn = request.Split(" ");
            if (stn.Length != 2 || !int.TryParse(stn[0], out int x) || !int.TryParse(stn[1], out int y) || (x > y))
            {
                return null;
            }
            Random random = new Random();
            return random.Next(x, y + 1);
        }
    }
}

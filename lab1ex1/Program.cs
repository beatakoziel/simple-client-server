using System;
using System.Net.Sockets;
using System.Net;

namespace lab1ex1
{
    class Program
    {
        private static Socket socket;
        static void Main(string[] args)
        {
            Connect();
            Console.WriteLine("Sending communicate...");
         
            string message = null;
            string textResult = null;
            while (true)
            {
                message = Console.ReadLine();
                if (message.Equals("quit"))
                    break;               
                sendMessage (message);
                Byte[] receivedBytes = new Byte[100];
                Byte[] sendBytes = new Byte[100];
                socket.Receive(receivedBytes, receivedBytes.Length, 0);
                textResult = System.Text.Encoding.ASCII.GetString(receivedBytes);
                if (textResult.Length > 0)
                {
                    Console.WriteLine(textResult);
                }
            }
        }
        

        private static void Connect()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress hostAddress = IPAddress.Parse("127.0.0.1");
            int hostPort = 2222;
            IPEndPoint hostEndPoint = new IPEndPoint(hostAddress, hostPort);
            socket.Connect(hostEndPoint);
        }

        private static void sendMessage(string message)
        {
            Byte[] messageBytes = System.Text.Encoding.ASCII.GetBytes(message);
            socket.Send(messageBytes, messageBytes.Length, 0);
        }
    }
}

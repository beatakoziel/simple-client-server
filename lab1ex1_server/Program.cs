using System;
using System.Net.Sockets;
using System.Net;

namespace lab1ex1_server
{
   

    class Program
    {
        private static TcpListener tcpListener;
        private static Socket socket;
        static void Main(string[] args)
        {
            Console.WriteLine("Server starting...");
            Serve();
        }

        static void Serve()
        {
            tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 2222);
            tcpListener.Start();
             socket = tcpListener.AcceptSocket();
            string message = string.Empty;
            string textResult = string.Empty;
            while (true)
            {
                Byte[] receivedBytes = new Byte[100];
                Byte[] sendBytes= new Byte[100];
                socket.Receive(receivedBytes, receivedBytes.Length, 0);
                textResult = System.Text.Encoding.ASCII.GetString(receivedBytes);
                if (textResult.Length > 0)
                {
                    Console.WriteLine(textResult);
                }
                message = Console.ReadLine();
                if (message.Equals("quit"))
                    break;
                sendBytes = System.Text.Encoding.ASCII.GetBytes(message);
                socket.Send(sendBytes, sendBytes.Length, 0);
            }
            tcpListener.Stop();
        }

        private static void sendMessage(string message)
        {
            Byte[] messageBytes = System.Text.Encoding.ASCII.GetBytes(message);
            socket.Send(messageBytes, messageBytes.Length, 0);
        }
    }
}

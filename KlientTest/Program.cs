using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace KlientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Fredrik Habib 

            string address = "127.0.0.1";
            int port = 8001;

            //Ansluter till servern
            Console.WriteLine("Ansluter...");
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(address, port);
            Console.WriteLine("Ansluten!");

            //skriver in meddelandet som ska skickas
            Console.Write("Skriv in meddelandet: ");
            String message = Console.ReadLine();

            //konvertera meddelande till ASCII-bytes eller  UTF-8
            Byte[] bMessage = System.Text.Encoding.ASCII.GetBytes(message);

            //Skicka iväg meddelandet 
            Console.WriteLine("Skickar...");
            NetworkStream tcpStream = tcpClient.GetStream();
            tcpStream.Write(bMessage, 0, bMessage.Length);

            tcpClient.Close();

        }
    }
}

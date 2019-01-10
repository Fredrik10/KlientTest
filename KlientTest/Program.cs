using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace KlientTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Fredrik Habib 
            while (true)
            {
                try
                {
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

                    //Tag emot meddelanden från servern:
                    Byte[] bRead = new byte[256];
                    int bReadSize = tcpStream.Read(bRead, 0, bRead.Length);

                    //Konverterar meddelandet till ett string objekt och de skrivs ut:
                    string read = "";
                    for (int i = 0; i < bReadSize; i++)
                        read += Convert.ToChar(bRead[i]);
                    Console.WriteLine("Servern säger: " + read);

                    //Stäng anslutningen:
                    tcpClient.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
        }
    }
}

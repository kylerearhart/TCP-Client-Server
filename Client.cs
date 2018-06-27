using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TCPClientConsole
{
    class Program
    {/*
        The purpose of this program is to create a TCP Client.
        Given a client and a server, the two will communicate to send
        messages back and forth once a connection has been established.
     */
        static void Main(string[] args)
        {
            //create TCP Socket
            TcpClient tcp = new TcpClient();
            tcp.Connect("ip_address_goes_here", 11000);

            string message = "";
            while (true)
            {
                Console.WriteLine("Enter message to send: ");
                message = Console.ReadLine();

                //exit connection
                if (message == "EXIT")
                    break;

                //get a client stream for reading and writing
                NetworkStream stream = tcp.GetStream();

                //send data to the connected TCP Server
                byte[] sendData = Encoding.ASCII.GetBytes(message);
                stream.Write(sendData, 0, sendData.Length);
                Console.WriteLine("\nSent: {0}", message);


                //Receive TCP Server Response\\

                //buffer to store response bytes
                byte[] data = new byte[256];
                string responseData = "";

                //read server response bytes
                int bytes = stream.Read(data, 0, data.Length);
                responseData = Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("\nReceived: {0}", responseData + "\n");
            }

            //stream.Close();
            tcp.Close();

            Console.WriteLine("\nPress Enter to close window.");
            Console.Read();
        }
    }
}

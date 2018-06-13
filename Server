using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TCPServerConsole
{
    class Program
    {/*
        The purpose of this program is to create a TCP Listener
        that will accept a client's request for connection. The two
        programs (client and server) will communicate to send messages
        back and forth once a connection has been established.
     */
        static void Main(string[] args)
        {
            //create TCP Listener
            IPAddress ip = IPAddress.Parse("ip_address_goes_here");
            TcpListener listen = new TcpListener(ip, 11000);

            //start listening for client requests
            listen.Start();

            //buffer to store the response bytes
            byte[] data = new byte[256];
            string receiveData = "";

            while(true)
            {
                Console.Write("Waiting for a connection...");

                //perform blocking call to accept requests
                TcpClient tcp = listen.AcceptTcpClient();
                Console.WriteLine("Connected!");
              
                //stream object for reading and writing
                NetworkStream stream = tcp.GetStream();

                int i;
                while((i = stream.Read(data, 0, data.Length)) != 0)
                {
                    receiveData = Encoding.ASCII.GetString(data, 0, i);
                    Console.WriteLine("\nReceived: " + receiveData);

                    Console.WriteLine("\nEnter a response to send back:");
                    string send = Console.ReadLine();

                    //exit connection
                    if (send == "EXIT")
                        break;

                    //send back a response
                    byte[] msg = Encoding.ASCII.GetBytes(send);
                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine("\nSent: " + send);
                }

                tcp.Close();
            }
        }
    }
}

using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ServerDelay
{
    public class ClientСonnection
    {
        public TcpClient client;
        public ClientСonnection(TcpClient tcpClient)
        {
            client = tcpClient;
        }        
        public void ServerResponse()
        {            
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] bytes = new byte[64];                
                    int bytesReadCount = stream.Read(bytes, 0, bytes.Length);
                    string request = System.Text.Encoding.UTF8.GetString(bytes, 0, bytesReadCount);
                    Console.WriteLine($"Received: {request}.");
                    int number;
                    int data;
                    bool isInt = int.TryParse(request, out number);
                    if (isInt) data = int.Parse(request) * int.Parse(request);
                        else data = -1;
                    byte[] response = System.Text.Encoding.UTF8.GetBytes(data.ToString());
                    Thread.Sleep(500);
                    stream.Write(response, 0, response.Length);
                    Console.WriteLine($"Sent: {data}.");
                    stream.Close();
                    client.Close();               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }

    class Program
    {
        const int port = 13000;
        static TcpListener listener;
        static void Main(string[] args)
        {
            try
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
                listener.Start();
                Console.WriteLine("Waiting for connections...");
                while (true)
                {
                    TcpClient tcpClient = listener.AcceptTcpClient();
                    ClientСonnection newClient = new ClientСonnection(tcpClient);
                    Thread clientThread = new Thread(new ThreadStart(newClient.ServerResponse));
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}

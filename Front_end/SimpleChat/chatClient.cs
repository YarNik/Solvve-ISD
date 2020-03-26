using System;
using System.Net.Sockets;

namespace ChatClient
{
    class Program
    {
        static string name;
        const string serverAddr = "127.0.0.1";        
        const int port = 13000;
        static NetworkStream stream;
        static TcpClient client;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name");           
            string messageName = Console.ReadLine();
            //Console.WriteLine("Enter server address(127.0.0.1)");
            //string serverAddr = Console.ReadLine();
            try
            {
                client = new TcpClient(serverAddr, port);
                var dataName = System.Text.Encoding.UTF8.GetBytes(messageName);                
                stream = client.GetStream();
                stream.Write(dataName, 0, dataName.Length);
                
                while (true)
                {
                    System.Threading.Thread.Sleep(300);                                            
                    if (stream.DataAvailable)
                    {
                        byte[] responseData = new byte[512];
                        int bytes = stream.Read(responseData, 0, responseData.Length);
                        string response = System.Text.Encoding.UTF8.GetString(responseData, 0, bytes);
                        Console.WriteLine(response);
                    }                    
                    if (Console.KeyAvailable == true)
                    {
                        string message = Console.ReadLine();
                        byte[] dataMessage = System.Text.Encoding.UTF8.GetBytes(message);
                        stream.Write(dataMessage, 0, dataMessage.Length);
                    }
                }                   
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception {0}", e);
                Console.ReadLine();
            }
        }        
    }
}
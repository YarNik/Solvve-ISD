using System;
using System.Net;
using System.Net.Sockets;

namespace SimpleServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("simple server!");
            try
            {
                int port = 13000;
                var localAddr = IPAddress.Parse("127.0.0.1");
                var server = new TcpListener(localAddr, port);
                server.Start();
                var bytes = new byte[1024];
                while (true)
                {
                    Console.WriteLine("Waiting for connection...");
                    var client = server.AcceptTcpClient();
                    NetworkStream stream = client.GetStream();
                    var bytesReadCount = stream.Read(bytes, 0, bytes.Length);
                    string request = System.Text.Encoding.UTF8.GetString(bytes, 0, bytesReadCount);
                    Console.WriteLine("resive: {0}", request);
                    string content =
                        "<!doctype html>\r\n" +
                        "<html>\r\n" +
                        "<head></head>\r\n" +
                        "<body>\r\n" +
                        "<h2>HELLO USER</h2>\r\n" +
                        "</body>\r\n" +
                        "</html>";
                    string data =
                        "HTTP/1.0 200 OK\r\n" +
                        "Server: MyServer\r\n" +
                        "Content-Type: text/html\r\n" +
                        "Content-Length: " + content.Length + "\r\n\r\n";

                    byte[] response = System.Text.Encoding.UTF8.GetBytes(data + content);
                    stream.Write(response, 0, response.Length);
                    Console.WriteLine("sent: {0}", data);
                    //stream.Close();
                    client.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}

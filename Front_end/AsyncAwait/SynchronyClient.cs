using System;
using System.Net.Sockets;
using System.Diagnostics;

namespace SynchronyClient
{
    class Program
    {
        const int port = 13000;
        const string address = "127.0.0.1";
        static TcpClient client = null;
        static void WebRequest(int i)
        {
            try
            {
                client = new TcpClient(address, port);
                NetworkStream stream = client.GetStream();
                byte[] request = System.Text.Encoding.UTF8.GetBytes(i.ToString());
                stream.Write(request, 0, request.Length);                
                var responseData = new byte[256];
                int bytesRead = stream.Read(responseData, 0, responseData.Length);
                var responseMessage = System.Text.Encoding.UTF8.GetString(responseData, 0, bytesRead);               
                Console.WriteLine($"Sent {i}, received {responseMessage}");
                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 1; i <= 10; i++)
            {
                WebRequest(i);
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}.{1:00}",
                ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            Console.ReadLine();
        }
    }
}

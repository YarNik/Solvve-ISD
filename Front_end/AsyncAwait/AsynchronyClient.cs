using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace AsynchronyClient
{
    class Program
    {
        const int port = 13000;
        const string address = "127.0.0.1";
        static string responseMessage;              
        static string WebRequest(int i)
        {           
            try
            {
                TcpClient client = new TcpClient(address, port);
                NetworkStream stream = client.GetStream();
                byte[] request = System.Text.Encoding.UTF8.GetBytes(i.ToString());
                stream.Write(request, 0, request.Length);                
                var responseData = new byte[256];
                int bytesRead = stream.Read(responseData, 0, responseData.Length);
                responseMessage = System.Text.Encoding.UTF8.GetString(responseData, 0, bytesRead);                
            }
            catch (Exception ex)
            {               
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            return responseMessage;
        }
        static async void WebRequestAsinc(int num)
        {            
            string response = await Task.Run(() => WebRequest(num));           
            Console.WriteLine($"Sent {num}, received {response}");            
        }
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 1; i <= 10; i++)
            {
                WebRequestAsinc(i);
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

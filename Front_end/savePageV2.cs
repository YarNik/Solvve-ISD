using System;
using System.IO;
using System.Net.Sockets;

namespace SavePageVer_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the needed site (selin.in.ua)");
            string serverAddr = Console.ReadLine();
            Console.WriteLine("Enter the file name (output.html)");
            string fileName = Console.ReadLine();
            //string fileName = "output.html";
            //string serverAddr = "selin.in.ua";
            DirectoryInfo dirInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            var directory = dirInfo.Parent.Parent.Parent;     // file will be saved in root directory of project
            string writePath = String.Format(@"{0}\{1}", directory, fileName);
            
            var message = "GET /index.html HTTP/1.0\n\n";
            try
            {
                var port = 80;                
                var client = new TcpClient(serverAddr, port);
                var data = System.Text.Encoding.UTF8.GetBytes(message);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);

                var responseData = new byte[65536];
                int bytesRead = stream.Read(responseData, 0, responseData.Length);
                var responseMessage = System.Text.Encoding.UTF8.GetString(responseData, 0, bytesRead);
                Console.WriteLine("Received {0}", responseMessage);

                string bodyResponse = responseMessage.Substring(responseMessage.IndexOf("\n\n"));
                System.IO.File.WriteAllText(writePath, bodyResponse);
                //Console.WriteLine(bodyResponse);
                Console.ReadLine();
                stream.Close();
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception {0}", e);
                Console.ReadLine();
            }
        }
    }
}
    
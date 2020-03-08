using System;
using System.IO;
using System.Net.Sockets;

namespace SavePageV3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter the needed site (http://selin.in.ua/solvve/html.html)");
            //string fullUrl = Console.ReadLine();
            //Console.WriteLine("Enter the file name (output.html)");
            //string fileName = Console.ReadLine();
            string fileName = "output.html";            
            string fullUrl = "http://selin.in.ua/solvve/html.html";
            DirectoryInfo dirInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            var directory = dirInfo.Parent.Parent.Parent;     // file will be saved in root directory of project
            string writePath = String.Format(@"{0}\{1}", directory, fileName);
            
            try
            {
                string fullUrlNotHttp = fullUrl.IndexOf("http://") == -1 ? fullUrl : fullUrl.Substring(7);
                string host = fullUrlNotHttp.IndexOf("/") == -1 ? fullUrlNotHttp : fullUrlNotHttp.Substring(0, fullUrlNotHttp.IndexOf("/"));
                string pageAddr = fullUrlNotHttp.IndexOf("/") == -1 ? "" : fullUrlNotHttp.Substring(fullUrlNotHttp.IndexOf("/") + 1);                
                string message = String.Format("GET /{0} HTTP/1.0\nHost: {1}\n\n", pageAddr, host);
                var port = 80;

                var client = new TcpClient(host, port);
                var data = System.Text.Encoding.UTF8.GetBytes(message);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);

                var responseData = new byte[65536];
                int bytesRead = stream.Read(responseData, 0, responseData.Length);
                var responseMessage = System.Text.Encoding.UTF8.GetString(responseData, 0, bytesRead);
                Console.WriteLine("Received {0}", responseMessage);
                string bodyResponse = responseMessage.Substring(responseMessage.IndexOf("\r\n\r\n"));                
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

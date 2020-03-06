using System;
using System.Net;
using System.IO;
using System.Text;

namespace SavePage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the needed site (selin.in.ua/index.html)");
            string siteName = Console.ReadLine();
            Console.WriteLine("Enter the file name (output.html)");
            string fileName = Console.ReadLine();
            //string fileName = "output.html";
            //string siteName = "selin.in.ua/index.html";
            DirectoryInfo dirInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);            
            var directory = dirInfo.Parent.Parent.Parent;     // file will be saved in root directory of project
            string writePath = String.Format(@"{0}\{1}", directory, fileName);
            string site = String.Format("http://www.{0}", siteName);
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(site);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                using (StreamReader stream = new StreamReader(
                     response.GetResponseStream(), Encoding.UTF8))
                {
                    string Page = stream.ReadToEnd();
                    System.IO.File.WriteAllText(writePath, Page);                    
                    Console.WriteLine(Page);                    
                    Console.ReadLine();
                }
                response.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception {0}", e);
                Console.ReadLine();
            }
        }
    }
}

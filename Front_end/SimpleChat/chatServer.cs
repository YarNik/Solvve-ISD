using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace ChatServer
{
    class Client
    {
        internal string clientName { get; private set; }
        internal TcpClient clientTcpClient { get; private set; }
        internal NetworkStream clientStream { get; private set; }       
        public Client(TcpClient tcpClient, NetworkStream Stream, string name)
        {
            clientTcpClient = tcpClient;
            clientName = name;
            clientStream = Stream;            
        }
    }
    class Program
    {
        static List<Client> clients = new List<Client>();
        static void AddClient(Client client)
        {
            clients.Add(client);
        }
        static void ListenNewConnect(TcpListener server)
        {
            Client newClient;
            bool add = true;
            var bytes = new byte[512];
            var tcpClient = server.AcceptTcpClient();
            NetworkStream stream = tcpClient.GetStream();
            var bytesReadCount = stream.Read(bytes, 0, bytes.Length);
            string request = System.Text.Encoding.UTF8.GetString(bytes, 0, bytesReadCount);                   
            if (clients.Count == 0)
            {
                newClient = new Client(tcpClient, stream, request);
                AddClient(newClient);
                Console.WriteLine($"added: {request}");
            }else
            { 
                foreach (Client client in clients)
                {
                    if (request == client.clientName)
                    {
                        byte[] refuse = System.Text.Encoding.UTF8.GetBytes("Name is busy. Disconnection...");
                        stream.Write(refuse, 0, refuse.Length);
                        add = false;
                        stream.Close();
                        tcpClient.Close();                       
                        break;
                    }                    
                }
                if (add)
                {
                    newClient = new Client(tcpClient, stream, request);
                    AddClient(newClient);
                    Console.WriteLine($"added {request}");
                    SendMessage(request, $"{request} went to chat.");
                }
            }        
        }
        static string ReciveMessage(NetworkStream clientStream)
        {
            var bytes = new byte[512];
            var bytesReadCount = clientStream.Read(bytes, 0, bytes.Length);
            string request = System.Text.Encoding.UTF8.GetString(bytes, 0, bytesReadCount);            
            return request;
        }
        static void SendMessage(string name, string message)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
            foreach (Client client in clients)
            {
                if (client.clientName != name)
                {
                    client.clientStream.Write(data, 0, data.Length);
                } 
            }
        }
        static void ClientQuit(string name)
        {
            Console.WriteLine($"{name} left the chat.");
            SendMessage(name, $"{name} left the chat.");
            Client client = clients.FirstOrDefault(cl => cl.clientName == name);
            client.clientStream.Close();
            client.clientTcpClient.Close();
            clients.Remove(client);
        }

        const string serverAddr = "127.0.0.1";
        const int port = 13000;
        static void Main(string[] args)
        {
            Console.WriteLine("Running chat server!");
            try
            {               
                var localAddr = IPAddress.Parse(serverAddr);
                var server = new TcpListener(localAddr, port);
                server.Start();
                Client removedClient = null;

                while (true)
                {
                    System.Threading.Thread.Sleep(300);                   
                    if (removedClient != null)
                    {
                        ClientQuit(removedClient.clientName);
                        removedClient = null;
                    }
                    if (server.Pending())
                    {                       
                        ListenNewConnect(server);
                    }
                    foreach (Client client in clients)
                    {
                        if (client.clientStream.DataAvailable)
                        {
                            string message = ReciveMessage(client.clientStream);
                            Console.WriteLine($"message from: {client.clientName}: {message}");
                            if (message == ".quit")
                            {
                                removedClient = client;                                
                            }
                            else SendMessage(client.clientName, $"{client.clientName}: {message}");
                        }                            
                    }                   
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
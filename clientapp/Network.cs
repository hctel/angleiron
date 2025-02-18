using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace clientapp
{
    public class Item
    {
        public string name { get; }
        public double price { get; }

        private TcpClient client;

        public Item(string name, string price)
        {
            this.name = name;
            this.price = double.Parse(price);
        }
    }

    public class Network
    {
        private string serverIp;
        private int port;

        private IPEndPoint ipEndPoint;
        private TcpClient client;

        public Network(string serverIp, int port)
        {
            this.serverIp = serverIp;
            this.port = port;
            ipEndPoint = new IPEndPoint(Dns.GetHostEntry(serverIp).AddressList[0], port);
            client = new TcpClient();
        }

        public List<Item> getItems()
        {
            List<Item> itemList = new List<Item>();
            List<string> list = get("SHOWTYPES");
            if (list[0].Equals("TYPELIST"))
            {
                
                string[] items = list[1].Split(';');
                foreach(string i in items)
                {
                    Item item = new Item(i.Split('/')[0], i.Split('/')[1]);
                    itemList.Add(item);
                }
            }
            return itemList;
        }

        public string authUser(string mail, string password)
        {
            List<string> list = get($"AUTH&{mail}&{password}");
            if (list[0].Equals("AUTHOK"))
            {
                return list[1];
            }
            return "";
        }

            private List<string> get(string request)
        {
            client.Connect(Dns.GetHostAddresses(serverIp), port);
            NetworkStream stream = client.GetStream();
            byte[] bytesOut = Encoding.UTF8.GetBytes(request);
            stream.Write(bytesOut, 0, bytesOut.Length);
            byte[] dataIn = new byte[client.ReceiveBufferSize];
            int length = stream.Read(dataIn, 0, dataIn.Length);
            string message = Encoding.ASCII.GetString(dataIn, 0, length);
            Debug.WriteLine($"Received from server: {message}");

            return message.Split('&').ToList();
        }
        
    }
}
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

    public class Kit
    {
        public int id { get; }
        public string name { get; }
        public string dimension { get; }
        public double price { get; }
        public string colors_available { get; }
        public string options_available { get; }
        public string image { get; }

        public Kit(int id, string name, string dimension, double price, string colors_available, string options_available, string image)
        {
            this.id = id;
            this.name = name;
            this.dimension = dimension;
            this.price = price;
            this.colors_available = colors_available;
            this.options_available = options_available;
            this.image = image;
        }

        public override string ToString()
        {
            return $"MODEL DETAIL:\n  id:{id}\n  name:{name}\n  dim:{dimension}\n  price:{price}\n  colors:{colors_available}\n  options:{options_available}\n  imageName{image}";
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
        }

        public List<Kit> getItems()
        {
            List<Kit> itemList = new List<Kit>();
            List<string> list = get("SHOWTYPES");
            if (list[0].Equals("TYPELIST"))
            {
                
                string[] items = list[1].Split(';');
                foreach(string i in items)
                {
                    string[] details = i.Split('/');
                    Kit item = new Kit(Int32.Parse(details[0]), details[1], details[2], Double.Parse(details[3]), details[4], details[5], details[6]);
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
            else if(list[0].Equals("AUTHERR"))
            {
                return list[1];
            }
            else return "UNKERR";
        }

            private List<string> get(string request)
        {
            client = new TcpClient();
            client.Connect(Dns.GetHostAddresses(serverIp), port);
            NetworkStream stream = client.GetStream();
            byte[] bytesOut = Encoding.UTF8.GetBytes(request);
            stream.Write(bytesOut, 0, bytesOut.Length);
            byte[] dataIn = new byte[client.ReceiveBufferSize];
            int length = stream.Read(dataIn, 0, dataIn.Length);
            string message = Encoding.ASCII.GetString(dataIn, 0, length);
            Debug.WriteLine($"Received from server: {message}");
            client.Close();
            return message.Split('&').ToList();
        }
        
    }
}
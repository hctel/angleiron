using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace merchandapp
{

    public class OrderSummary
    {
        public int orderID { get; set; }
        public string orderName { get; set; }
        public string orderStatus { get; set; }
        public string orderDate { get; set; }
        public string orderStock { get; set; }

        public OrderSummary() { }

        public OrderSummary(string orderId, string orderName, string orderStatus, string orderDate, string orderStock) {
            this.orderID = Int32.Parse(orderId);
            this.orderName = orderName;
            this.orderStatus = orderStatus;
            this.orderDate = orderDate;
            this.orderStock = orderStock;
        }
    }

    public class OrderPart
    {
        public int id { get; }
        public string name { get; }
        public int quantity { get; }
        public bool inStock { get; }
        public OrderPart(int id, string name, int quantity, bool inStock)
        {
            this.id = id;
            this.name = name;
            this.quantity = quantity;
            this.inStock = inStock;
        }
    }

    public class Order
    {
        public int orderID { get; }
        public List<OrderPart> parts { get; } = new List<OrderPart>();

        public Order(string orderID, string[][] items)
        {
            this.orderID = Int32.Parse(orderID);
            foreach (string[] part in items)
            {
                parts.Add(new OrderPart(Int32.Parse(part[0]), part[3], Int32.Parse(part[1]), part[2].Equals("1")));
            }
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

        public List<OrderSummary> getOrders()
        {
            List<OrderSummary> summaries = new List<OrderSummary>();
            List<string> list = get("SHOWORDERS");
            if (list[0].Equals("ORDERLIST"))
            {
                string[] orders = list[1].Split(';');
                foreach (string o in orders)
                {
                    string[] order = o.Split('/');
                    OrderSummary summary = new OrderSummary(order[0], order[1], order[2], order[3], order[4]);
                    summaries.Add(summary);
                }
            }
            return summaries;
        }

        public Order getOrderDetails(int orderID)
        {
            List<string> list = get($"DETAILORDER&{orderID}");
            if (list[0].Equals("ORDERDETAIL"))
            {
                string[] items = list[1].Split(';');
                string[][] orderItems = new string[items.Length][];
                for (int i = 0; i < items.Length; i++)
                {
                    orderItems[i] = items[i].Split('/');
                }
                return new Order(orderID.ToString(), orderItems);
            }
            return null;
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

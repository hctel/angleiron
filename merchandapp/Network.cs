﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.ComponentModel;

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

        public OrderSummary(string orderId, string orderName, string orderStatus, string orderDate, string orderStock)
        {
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
    public class PartSummary
    {
        public int ID { get; }
        public string Name { get; }
        public int QuantityNeeded { get; }
        public int QuantityOrdered { get; }
        public int QuantityInStock { get; }

        public PartSummary(int ID,  int QuantityInStock, int QuantityNeeded, int QuantityOrdered, string Name)
        {
            this.ID = ID;
            this.Name = Name;
            this.QuantityNeeded = QuantityNeeded;
            this.QuantityInStock = QuantityInStock;
            this.QuantityOrdered = QuantityOrdered;
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
                //Debug.WriteLine(part[0]);
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
            //client = new TcpClient();
        }

        public void debugCommand(string command)
        {
            Debug.WriteLine(get(command));
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
                string[] items = list[2].Split(';');
                string[][] orderItems = new string[items.Length][];
                for (int i = 0; i < items.Length; i++)
                {
                    orderItems[i] = items[i].Split('/');
                    orderItems[i][2] = Int32.Parse(orderItems[i][2]) >= Int32.Parse(orderItems[i][1]) ? "1" : "0"; // quantity in stock
                }

                return new Order(orderID.ToString(), orderItems);
            }
            return null;
        }
        public List<PartSummary> stockStatus()
        {
            List<PartSummary> partSummaries = new List<PartSummary>();
            List<string> list = get("STOCKCHK");
            if (list[0].Equals("STOCKSTS"))
            {
                string[] parts = list[1].Split(';');
                foreach (string obj in parts)
                {
                    string[] part = obj.Split('/');
                    PartSummary summary = new PartSummary(Int32.Parse(part[1]), Int32.Parse(part[2]), Int32.Parse(part[3]), Int32.Parse(part[4]), part[5]);
                    partSummaries.Add(summary);
                }

                return partSummaries;
            }
            return null;
        }
        public string updateStatus(int orderID)
        {
            return get("UPDATESTATUS" + "&" + orderID.ToString() + "&" + "COMPLETED")[0];
        }
        public int getStockToOrder(int partID)
        {
            return Int32.Parse(get("STOCKTOORDER" + "&" + partID.ToString())[1]);
        }
        public string orderStock(int partID, int quantity)
        {
            return get("ORDERSTOCK" + "&" + partID.ToString() + "&" + quantity.ToString())[0];
        }
        public string stockDelivered(int stockID, int quantity)
        {
            return get("STOCKDEDELIVERED" + "&" + stockID.ToString() + "&" + quantity.ToString())[0];
        }
        private List<string> get(string request)
        {
            Debug.WriteLine($"Sent to server: {request}");
            client = new TcpClient();
            client.Connect(Dns.GetHostAddresses(serverIp), port);
            NetworkStream stream = client.GetStream();
            byte[] bytesOut = Encoding.UTF8.GetBytes(request);
            stream.Write(bytesOut, 0, bytesOut.Length);
            byte[] dataIn = new byte[client.ReceiveBufferSize];
            int length = stream.Read(dataIn, 0, dataIn.Length);
            string message = Encoding.UTF8.GetString(dataIn, 0, length);
            Debug.WriteLine($"Received from server: {message}");
            client.Close();

            return message.Split('&').ToList();
        }

    }
}

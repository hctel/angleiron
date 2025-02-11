using System

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
            var ipEndPoint = new IPEndPoint(ipAddress, 13);
            client = new();
        }
    }

    public class Network
    {
        private string serverIp;
        private int port;

        public Network(string serverIp, int port)
        {
            this.serverIp = serverIp;
            this.port = port;
        }

        public Item[] getItems()
        {
            string[] list = get("SHOWTYPES");
            if (list[0].Equals("TYPELIST"))
            {
                Item[] itemList;
                string[] items = list[1].split(';');
                for(string i : items)
                {
                    Item item = new Item(i.split('/')[0], i.split('/')[1]);
                    itemList.Append(item);
                }
                return itemList;
            }
        }

        private string[] get(string request)
        {
            await client.ConnectAsync(ipEndPoint);
            await using NetworkStream stream = client.GetStream();
            await stream.WriteAsync(request);
            var buffer = new byte[1_024];
            int received = await stream.ReadAsync(buffer);

            return Encoding.UTF8.GetString(buffer, 0, received).split('&');
        }
        
    }
}
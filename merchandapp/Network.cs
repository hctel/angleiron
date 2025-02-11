using System;

namespace merchandapp
{
    public class Network
    {
        private string serverIP;
        private int port;
        public Network(string serverIP, int port)
        {
            this.serverIP = serverIP;
            this.port = port;
        }
    }
}

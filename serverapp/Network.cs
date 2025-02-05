using System;
using System.Net;
using System.Net.Sockets;

namespace backend
{
	public class Network
	{
		IPEndPoint endPoint;
		TcpListener listener;
        public Network(int port)
		{
			if (port < 1) throw new ArgumentOutOfRangeException("Port must be greater than 1");
            endPoint = new IPEndPoint(IPAddress.Any, port);
            listener = new TcpListener(endPoint);
        }
	}
}

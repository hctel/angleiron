using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace backend
{
	public class Network
	{
		private IPEndPoint endPoint;
		private TcpListener listener;
		private Thread thread;
		private bool cancelled = false;

        public Network(int port)
		{
			if (port < 1) throw new ArgumentOutOfRangeException("Port must be greater than 1");
            endPoint = new IPEndPoint(IPAddress.Any, port);
            listener = new TcpListener(endPoint);
			listener.Start();
            thread = new Thread(async () =>
			{
				for(; ; )
				{
					if(cancelled) break;
                    using TcpClient handler = await listener.AcceptTcpClientAsync();
					await using NetworkStream stream = handler.GetStream();

					StreamReader reader = new StreamReader(stream);
					StreamWriter writer = new StreamWriter(stream);

					byte[] dataIn = new byte[handler.ReceiveBufferSize];
					int length = stream.Read(dataIn, 0, dataIn.Length);
					string message = Encoding.ASCII.GetString(dataIn, 0, length);


                }
			});
			thread.Start();
        }
		
		public void kill()
		{
            cancelled = true;
			thread.Join();
			listener.Stop();
        }
	}
}

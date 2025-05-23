﻿using System;
using System.Diagnostics;
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

		private int port;
		private Func<string[], string, string> rcvFunc;

		public Network(int port, Func<string[], string, string> rcvFunc)
		{
			this.port = port;
			this.rcvFunc = rcvFunc;

			if (port < 1) throw new ArgumentOutOfRangeException("Port must be greater than 1");
            endPoint = new IPEndPoint(IPAddress.Any, port);
            listener = new TcpListener(endPoint);
			listener.Start();
            thread = new Thread(async () =>
			{
                Console.WriteLine("Network thread started");
                for (; ; )
				{
					if(cancelled) break;
                    using TcpClient handler = await listener.AcceptTcpClientAsync();
					await using NetworkStream stream = handler.GetStream();

					byte[] dataIn = new byte[handler.ReceiveBufferSize];
					int length = stream.Read(dataIn, 0, dataIn.Length);
					string message = Encoding.UTF8.GetString(dataIn, 0, length);
					string[] data = message.Split('&');

                    IPEndPoint remoteIpEndPoint = handler.Client.RemoteEndPoint as IPEndPoint;
					Console.WriteLine($"Request from {remoteIpEndPoint.Address.ToString()}: {message}");
					Console.Beep();

					string msgOut = rcvFunc(data, remoteIpEndPoint.Address.ToString());
					Console.WriteLine($"Reponse: {msgOut}");
                    var bytesOut = Encoding.UTF8.GetBytes(msgOut);
					try
					{
                        stream.Write(bytesOut);
                    } catch
					{
						stream.Close();
					}
                    
                }
			});
			thread.Start();
        }
		
		public void kill()
		{
            cancelled = true;
			thread.Join();
			listener.Stop();
			Console.WriteLine("Network thread stopped");
        }
	}
}

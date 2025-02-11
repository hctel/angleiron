// See https://aka.ms/new-console-template for more information
using backend;
using System;
string version = "0.0.1";
int port = 6210;

Console.WriteLine($"AngleIron server v{version}");
Console.WriteLine("Starting server...");
Network networkManager = new Network(port);
//...
Console.WriteLine($"Server started on port {port}");
Console.WriteLine("Press Q to stop the server");

for (; ; )
{
    if(Console.ReadKey().Key == ConsoleKey.Q)
    {
        break;
    }   
}

Console.WriteLine("Stopping server...");
networkManager.kill();

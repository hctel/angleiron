// See https://aka.ms/new-console-template for more information
using backend;
using System;

string version = "0.0.1";
int port = 6210;

Console.WriteLine($"AngleIron server v{version}");
Console.WriteLine("Starting server...");

Network networkManager = new Network(port, networkReceiveFunction); //TO DO LASTLY!!
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

string networkReceiveFunction(string[] data)
{
    /*
     * AUTHENTICATION:
     * 
     * Command: AUTH
     * Structure: AUTH&email&password
     * 
     * Responses:
     *  Sucessful: AUTHOK&sessionID&clientID&remoteIP
     *  Incorrect password: AUTHFAIL&NOPASSWD
     *  User not fount: AUTHFAIL&NOUSER
     */

    if (data[0].Equals("SHOWTYPES"))
    {
       /*
        * -nom
        * -prix*/
       return "TYPELIST&small dumb model/7.00;medium dumb model/15.00;big model/69.00";
    }
    return "NOFUNC";
}
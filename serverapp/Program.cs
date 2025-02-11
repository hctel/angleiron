// See https://aka.ms/new-console-template for more information
using backend;
using System;
string version = "0.0.1";
int port = 6210;

Console.WriteLine($"AngleIron server v{version}");
Console.WriteLine("Starting server...");

UserDB usersDatabase = new UserDB("localhost", "angleiron", "root", "root"); //CHANGE CREDENTIALS HERE

UserAuth userAuthenticator = new UserAuth(usersDatabase);


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
    if (data[0].Equals("AUTH"))
    {
        try
        {
            return "AUTHOK&" + userAuthenticator.authUser(data[1], data[2]).ToString();
        }
        catch (KeyNotFoundException e)
        {
            return "AUTHFAIL&NOUSER";
        }
        catch (Exception e)
        {
            return "AUTHFAIL&NOPASSWD";
        }
    }
    return "NOFUNC";
}
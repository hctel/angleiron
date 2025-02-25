// See https://aka.ms/new-console-template for more information
using backend;
using System;

string version = "0.0.1b";
int port = 80;

List<Session> sessions = new List<Session>();

Console.WriteLine($"AngleIron server v{version}");
Console.WriteLine("Starting server...");

DatabaseConnector dbcon = new DatabaseConnector("127.0.0.1", "angleiron", "root", "1234"); //CHANGE CREDENTIALS HERE

UserAuth userAuthenticator = new UserAuth((UserDB) dbcon);

Network networkManager = new Network(port, networkReceiveFunction); //TO DO LASTLY!!
Console.WriteLine("Press any key to enter");
Console.ReadKey();
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

string networkReceiveFunction(string[] data, string ipAddress)
{
    /*
     * Syntax error response : STXERR
     * Not implemented: NOTIMPL
     * 
     * LIST TYPES:
     * Command: SHOWTYPES
     * Response:
     *   TYPELIST&modelname1/price1;modelname2/price2;modelname3/price3; (etc.) 
     *   
     * LIST ORDERS:
     * Command: SHOWORDERS
     * Response:
     *   ORDERLIST&orderID1/orderName1/orderStatus1/orderDate1/orderStock1;orderID2/orderName2/orderStatus2/orderDate2/orderStock2; (etc.)
     * 
     * ORDER DETAILS:
     * Command: DETAILORDER&orderID
     * Responses:
     *   Sucessful: ORDERDETAIL&orderID&elemnt1/quantity1/available1;elemnt2/quantity2/available2;elemnt3/quantity3/available3; (etc.)
     * 
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

    else if (data[0].Equals("SHOWORDERS"))
    {
        return "NOTIMPL";
    }

    else if (data[0].Equals("DETAILORDER"))
    {
        return "NOTIMPL";
    }

    else if (data[0].Equals("UPDATESTATUS"))
    {
        if (data.Length != 3) return "STXERR";
        else
        {
            int orderId = Int32.Parse(data[1]);
            return "NOTIMPL";
        }
    }

    else if (data[0].Equals("DELORDER"))
    {
        if (data.Length != 2) return "STXERR";
        else
        {
            int orderId = Int32.Parse(data[1]);
            return "NOTIMPL";
        }
    }

    else if (data[0].Equals("BUYSTOCK")) { 
        if(data.Length != 3) return "STXERR";
        else
        {
            int componentId = Int32.Parse(data[1]);
            int quantity = Int32.Parse(data[2]);
            return "NOTIMPL";
        }
    }

    else if (data[0].Equals("AUTH"))
    {
        if (data.Length != 3)
        {
            return "STXERR";
        }
        else
        {
            try
            {
                Session session = userAuthenticator.authUser(data[1], data[2], ipAddress);
                sessions.Add(session);
                return "AUTHOK&" + session.ToString();
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
    }
    return "NOFUNC";
}
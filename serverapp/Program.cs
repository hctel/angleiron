// See https://aka.ms/new-console-template for more information
using backend;
using System;
using System.Diagnostics.Metrics;

string version = "0.0.1b";
int port = 80;

string hostname = "127.0.0.1";
string dataName = "angleiron";
string username = "root";
string password = "1234";

List<Session> sessions = new List<Session>();

Console.WriteLine($"AngleIron server v{version}");
Console.WriteLine("Starting server...");

UserDB dbcon = new UserDB(hostname, dataName, username, password); //CHANGE CREDENTIALS HERE
Order_DB orderDB = new Order_DB(hostname, dataName, username, password);
Stock_DB stockDB = new Stock_DB(hostname, dataName, username, password);
KitDB kitDB = new KitDB(hostname, dataName, username, password);
MaterialDB materialDB = new MaterialDB(hostname, dataName, username, password);
KIT_to_component kitToComponentDB = new KIT_to_component(hostname, dataName, username, password);

UserAuth userAuthenticator = new UserAuth( dbcon);
Stock_calculation stockCalculation = new Stock_calculation(stockDB);
Order_management order_manager = new Order_management(orderDB, stockDB, kitDB, materialDB, kitToComponentDB, stockCalculation);

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
        List<List<string>> orders = order_manager.get_orders();
        string response = "ORDERLIST&";
        foreach (List<string> order in orders)
        {
            response += order[0] + "/" + order[1] + "/" + order[2] + "/" + order[3] + "/" + order[4] + "/"+ order[5] + ";";
        }
        return response.Remove(response.Length - 1, 1); ;
    }
        

    else if (data[0].Equals("DETAILORDER"))
    {
        List<List<string>> orderDetails = order_manager.detail_order(Int32.Parse(data[1]));
        string response = "ORDERDETAIL&" + data[1] + "&";
        foreach (List<string> detail in orderDetails)
        {
            response += detail[0] + "/" + detail[1] + "/" + detail[2] +"/"+detail[3] + ";";
        }
        return response.Remove(response.Length - 1, 1); ;
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
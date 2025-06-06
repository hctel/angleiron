﻿// See https://aka.ms/new-console-template for more information
using backend;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Diagnostics.Metrics;

string version = "0.2.0";
int port = 0xe621;


//CHANGE CREDENTIALS HERE
string hostname = "127.0.0.1";
string dataName = "angle2";
string username = "root";
string password = "tarragon";

List<Session> sessions = new List<Session>();

Console.WriteLine($"AngleIron server v{version}");
Console.WriteLine("Starting server...");

UserDB dbcon = new UserDB(hostname, dataName, username, password);
OrderDB orderDB = new OrderDB(hostname, dataName, username, password);
StockDB stockDB = new StockDB(hostname, dataName, username, password);
KitDB kitDB = new KitDB(hostname, dataName, username, password);
MaterialDB materialDB = new MaterialDB(hostname, dataName, username, password);

UserAuth userAuthenticator = new UserAuth(dbcon);

OrderManager orderManager = new OrderManager(orderDB, kitDB, stockDB);
StockManager stockManager = new StockManager(stockDB);


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
     *
     * OrderStock :
     * Command: ORDERSTOCK
     * Structure: ORDERSTOCK&componentID&quantity
     *
     *response: 
     *  Sucessful: OK
     *  Syntax error: STXERR
     * 
     * Stock delivered:
     * Command: STOCKDEDELIVERED
     * Structure: STOCKDEDELIVERED&componentID&quantity
     *
     *response:
     *  Sucessful: OK
     *  Syntax error: STXERR
     *
     * Stock to order:
     * Command: STOCKTOORDER
     * Structure: STOCKTOORDER&componentID
     *
     *response:
     *  Sucessful: TOORDER&quantity
     *  Syntax error: STXERR
     *
     * New order:
     * Command: NEWORDER
     * Structure: NEWORDER&categoryID&clientID&already_paid&status&price
     *
     *response:
     *  Sucessful: OK
     *  Syntax error: STXERR
     *
     * Update status:
     * Command: UPDATESTATUS
     * Structure: UPDATESTATUS&orderID&status
     *
     *response:
     *  Sucessful: OK
     *  Syntax error: STXERR
     */

    if (data[0].Equals("SHOWTYPES"))
    {
        List<Kit> kits = kitDB.getAllKits();
        string response = "TYPELIST&";
        foreach (Kit kit in kits)
        {
            response += kit.ToString() + ";";
        }
        return response.Remove(response.Length - 1, 1); ;
    }

    else if (data[0].Equals("SHOWORDERS"))
    {
        List<List<string>> orders = orderManager.getOrders();
        if(orders.Count == 0) return "NOORDERS";
        string response = "ORDERLIST&";
        foreach (List<string> order in orders)
        {
            writeListToConsole(order);
            response += order[0] + "/" + order[1] + "/" + order[2] + "/" + order[3] + "/" + order[4] + ";";
        }
        return response.Remove(response.Length - 1, 1); ;
    }


    else if (data[0].Equals("DETAILORDER"))
    {
        List<List<string>> orderDetails = orderManager.detailOrder(Int32.Parse(data[1]));
        if (orderDetails.Count == 0) return "NOORDER";
        string response = "ORDERDETAIL&" + data[1] + "&";
        foreach (List<string> detail in orderDetails)
        {
            response += detail[0] + "/" + detail[1] + "/" + detail[2] + "/" + detail[3] + ";";
        }
        return response.Remove(response.Length - 1, 1); ;
    }

    else if (data[0].Equals("UPDATESTATUS"))
    {
        if (data.Length != 3) return "STXERR";
        else
        {
            int orderId = Int32.Parse(data[1]);
            orderManager.changeStatus(data[2], orderId);
            return "OK";
        }
    }

    else if (data[0].Equals("DELORDER"))
    {
        if (data.Length != 2) return "STXERR";
        else
        {
            int orderId = Int32.Parse(data[1]);
            orderManager.deleteRow(orderId);
            return "OK";
        }
    }

    else if (data[0].Equals("ORDERSTOCK"))
    {
        if (data.Length != 3) return "STXERR";
        else
        {
            int componentId = Int32.Parse(data[1]);
            int quantity = Int32.Parse(data[2]);
            stockDB.addInt("quantityOrder", quantity, componentId);
            return "OK";
        }
    }

    else if (data[0].Equals("STOCKCHK"))
    {
        string response = stockDB.getStockString();
        return response.Remove(response.Length - 1, 1);
    }

    else if (data[0].Equals("STOCKDEDELIVERED"))
    {
        if (data.Length != 3) return "STXERR";
        else
        {
            int componentId = Int32.Parse(data[1]);
            int quantity = Int32.Parse(data[2]);
            using (MySqlDataReader result = stockDB.getId(componentId))
            {
                result.Read();
                int new_quantity_to_order = result.GetInt32("quantityOrder") - quantity;
                int new_quantity = result.GetInt32("quantityInStock") + quantity;
                stockDB.updateINT("quantityOrder", new_quantity_to_order, componentId);
                stockDB.updateINT("quantityInStock", new_quantity, componentId);
                return "OK";
            }
        }
    }
    else if (data[0].Equals("STOCKTOORDER"))
    {
        if (data.Length != 2) return "STXERR";
        else {
            int componentId = Int32.Parse(data[1]);
            return "TOORDER&" + stockManager.getStockDiff(componentId);
        }
    }
    else if (data[0].Equals("NEWORDER"))
    {
        if (data.Length != 7) return "STXERR";
        else
        {
            int idcategory = Int32.Parse(data[1]);
            int idclient = Int32.Parse(data[2]);
            string already_paid = data[3];
            string status = data[4];
            double price = Double.Parse(data[5]);
            string color = data[6];
            orderManager.addOrder(idcategory, idclient, already_paid, status, price, color);
            return "OK";
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
    else if (data[0].Equals("NEWUSER"))
    {
        if (data.Length != 5)
        {
            return "STXERR";
        }
        else
        {
            string name = data[1];
            string address = data[2];
            string email = data[3];
            string password = data[4];
            userAuthenticator.createUser(name, address, email, password);
            return "OK";
        }
    }
    else if (data[0].Equals("DELUSER"))
    {
        if (data.Length != 2) return "STXERR";
        else
        {
            int id = Int32.Parse(data[1]);
            dbcon.deleteuser(id);
            return "OK";
        }
    }
    else if (data[0].Equals("UPDATEPRICE")){
        if (data.Length != 3) return "STXERR";
        else
        {
            //int id = Int32.Parse(data[1]);
            //double price = Double.Parse(data[2]);
            //stockCalculation.updateDouble("Price", price, id);
            //return "OK";
            return "NOTIMPL";
        }
    }

    return "NOFUNC";
}

void writeArrayToConsole(string[] a)
{
    foreach(string S in a) {
        Console.Write(a + ",");
    }
    Console.Write("\n\r");
}

void writeListToConsole(List<string> a)
{
    foreach (string S in a)
    {
        Console.Write(S + ",");
    }
    Console.Write("\n\r");
}
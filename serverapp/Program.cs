// See https://aka.ms/new-console-template for more information
using backend;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Diagnostics.Metrics;

string version = "0.0.1b";
int port = 0xe621;

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
Order_management order_manager = new Order_management(orderDB, stockDB, kitDB, materialDB, kitToComponentDB, stockCalculation, dbcon, userAuthenticator);
Kit_manager kitM = new Kit_manager(kitDB);

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
        List<Kit> kits = kitM.getKits();
        string response = "TYPELIST&";
        foreach (Kit kit in kits)
        {
            response += kit.ToString() + ";";
        }
        return response.Remove(response.Length - 1, 1); ;
    }

    else if (data[0].Equals("SHOWORDERS"))
    {   
        List<List<string>> orders = order_manager.get_orders();
        string response = "ORDERLIST&";
        foreach (List<string> order in orders)
        {
            response += order[1] + "/" + order[0] + "/" + order[2] + "/" + order[3] + "/"+order[4] + ";";
        }
        return response.Remove(response.Length - 1, 1); ;
    }
        

    else if (data[0].Equals("DETAILORDER"))
    {
        List<List<string>> orderDetails = order_manager.detail_order(Int32.Parse(data[1]));
        if (orderDetails.Count == 0) return "NOORDER";
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
            order_manager.change_satus(data[2], orderId);
            return "OK";
        }
    }

    else if (data[0].Equals("DELORDER"))
    {
        if (data.Length != 2) return "STXERR";
        else
        {
            int orderId = Int32.Parse(data[1]);
            order_manager.delete_row(orderId);
            return "OK";
        }
    }

    else if (data[0].Equals("ORDERSTOCK")) { 
        if(data.Length != 3) return "STXERR";
        else
        {
            int componentId = Int32.Parse(data[1]);
            int quantity = Int32.Parse(data[2]);
            using(MySqlDataReader result = stockDB.getIdcomponent(componentId)){
                result.Read();
                int new_quantity_to_order = result.GetInt32("Quantity_order") + quantity;
                stockCalculation.updateInt("Quantity_order", new_quantity_to_order, componentId);
                return "OK";
            }
        }
    }
    else if (data[0].Equals("STOCKDEDELIVERED")){
            int componentId = Int32.Parse(data[1]);
            int quantity = Int32.Parse(data[2]);
            using(MySqlDataReader result = stockDB.getIdcomponent(componentId)){
                result.Read();
                int new_quantity_to_order = result.GetInt32("Quantity_order") - quantity;
                int new_quantity = result.GetInt32("Quantity") + quantity;
                stockCalculation.updateInt("Quantity_order", new_quantity_to_order, componentId);
                stockCalculation.updateInt("Quantity", new_quantity, componentId);
                return "OK";
            }
    }
    else if (data[0].Equals("STOCKTOORDER")){
        int componentId = Int32.Parse(data[1]);
        stockCalculation.check(componentId);
        return "TOORDER&"+stockCalculation.get_to_order();
    }
    else if (data[0].Equals("NEWORDER")){
        if(data.Length != 7) return "STXERR";
        else
        {
            int idcategory = Int32.Parse(data[1]);
            int idclient = Int32.Parse(data[2]);
            string already_paid = data[3];
            string status = data[4];
            double price = Double.Parse(data[5]);
            string date = data[6];
            order_manager.add_order(idcategory, idclient, already_paid, status, price, date);
            order_manager.management();
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
        if(data.Length != 5) 
        {
            return "STXERR";
        }
        else
        {
            string name = data[1];
            string address = data[2];
            string email = data[3];
            string password = data[4];
            userAuthenticator.createUser(name,address ,email, password);
            return "OK";
        }
    }
    else if(data[0].Equals("DELUSER"))
    {
        if(data.Length != 2) return "STXERR";
        else
        {
            int id = Int32.Parse(data[1]);
            dbcon.deleteuser(id);
            return "OK";
        }
    
    }
    return "NOFUNC";
}
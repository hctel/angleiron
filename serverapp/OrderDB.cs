using System;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace backend
{
    public class Order_DB : DatabaseConnector
    {
        public Order_DB(string server, string databaseName, string username, string password) : base(server, databaseName, username, password)
        {
        }

        public MySqlDataReader getIdcomposant(int idcomponent)
        {
          return read(String.Format("SELECT * FROM Stock WHERE id_component={0};", idcomponent));
        }

        public void addOrder(int idcomponent, int id_client, int already_paid, int status, int price)
        {
            execute(String.Format("INSERT INTO commandes (id_client, id_componnt, Price, Already_paid, Status) VALUES ({0}, {1}, {2}, {3}, {4});", 
            id_client, idcomponent, price, already_paid,status));
        }
    }
}
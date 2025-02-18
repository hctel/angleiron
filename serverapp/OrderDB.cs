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

        public MySqlDataReader getIdOrder(int idcomponent)
        {
          return read(String.Format("SELECT * FROM Orders WHERE idorder={0};", idcomponent));
        }

        public void addOrder(int idcomponent, int id_client, int already_paid, int status, int price)
        {
            execute(String.Format("INSERT INTO commandes (id_client, id_category, Price, Already_paid, Status) VALUES ({0}, {1}, {2}, {3}, {4});", 
            id_client, idcomponent, price, already_paid,status));
        }
        public void updateINT(string name_collum, int new_value, int id){
            execute(String.Format("UPDATE OrderS SET '{0}'={1} WHERE idorder={2}",name_collum, new_value, id));
        }
    }
}
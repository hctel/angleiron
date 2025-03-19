using System;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace backend
{
    public class Stock_DB : DatabaseConnector
    {
        public Stock_DB(string server, string databaseName, string username, string password) : base(server, databaseName, username, password)
        {
        }

        public MySqlDataReader getIdcomponent(int idcomponent)
        {
            return read(String.Format("SELECT * FROM Stock WHERE id_component={0};", idcomponent));
        }

        public MySqlDataReader getStock(int id)
        {
            return read(String.Format("SELECT * FROM Stock WHERE id_stock={0};", id));
        }

        public void addStock(string supplier, int idcomponent, int quantity, int quantity_client, int quantity_order, double price, int delivery_duration)
        {
            execute(String.Format("INSERT INTO Stock (id_component, Quantity, Quantity_client, Quantity_order, supplier, Price, delivery_duration) VALUES ({0}, {1}, {2}, {3}, '{4}', {5}, {6});",
            idcomponent, quantity, quantity_client, quantity_order, supplier, price, delivery_duration));
        }
        public void updateINT(string name_collum, int new_value, int id)
        {
            execute(String.Format("UPDATE Stock SET '{0}'={1} WHERE id_component={2};", name_collum, new_value, id));
        }

        public List<int> getAllComponents()
        {
            List<int> ints = new List<int>();
            using (MySqlDataReader result = read("SELECT id_component FROM Stock;"))
            {
                while (result.Read())
                {
                    ints.Add(result.GetInt32("id_component"));
                }
            }
            return ints;
        }

        public List<int> getAllStockIdsFromComponent(int componentId)
        {
            {
                List<int> ints = new List<int>();
                using (MySqlDataReader result = read($"SELECT id_stock FROM Stock WHERE id_component={componentId};"))
                {
                    while (result.Read())
                    {
                        ints.Add(result.GetInt32("id_stock"));
                    }
                }
                return ints;
            }
        }
    }
}

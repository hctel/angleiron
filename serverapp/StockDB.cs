using System;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace backend
{
    public class StockDB : DatabaseConnector
    {
        private DatabaseConnector updater;
        public StockDB(string server, string databaseName, string username, string password) : base(server, databaseName, username, password)
        {
            updater = new DatabaseConnector(server, databaseName, username, password); // Initialize the updater with the same connection parameters
        }

        public MySqlDataReader getAllStock()
        {
            return read("SELECT * FROM stock;");
        }

        public MySqlDataReader getId(int idcomponent)
        {
            return read(String.Format("SELECT * FROM stock WHERE idStock={0};", idcomponent));
        }


        public MySqlDataReader getIdcomponent(int idcomponent)
        {
            return read(String.Format("SELECT * FROM component WHERE idComponent={0};", idcomponent));
        }

        public MySqlDataReader getComponentInStock(int idcomponent, int quantity)
        {
            return read(String.Format("SELECT * FROM stock WHERE idComponent={0} AND quantityInStock > {1} ORDER BY price DESC;", idcomponent, quantity));
        }

        public MySqlDataReader getComponents(int idcomponent) {
            return read(String.Format("SELECT * FROM stock WHERE idComponent={0} ORDER BY price DESC;", idcomponent));
        }

        public MySqlDataReader getStock(int id)
        {
            return read(String.Format("SELECT * FROM stock WHERE idStock={0};", id));
        }

        public void addStock(string supplier, int idcomponent, int quantity, int quantityClient, int quantity_order, double price, int deliveryDuration)
        {
            updater.execute(String.Format("INSERT INTO stock (idComponent, quantityInStock, quantityClient, quantityOrder, supplier, price, deliveryDuration) VALUES ({0}, {1}, {2}, {3}, '{4}', {5}, {6});",
            idcomponent, quantity, quantityClient, quantity_order, supplier, price, deliveryDuration));
        }
        public void updateINT(string nameCollum, int new_value, int id)
        {
            updater.execute(String.Format("UPDATE stock SET {0}={1} WHERE idComponent={2};", nameCollum, new_value, id));
        }
        public void addInt(string nameCollum, int new_value, int id)
        {
            int prevResult = 0;
            using (MySqlDataReader result = read(String.Format("SELECT {0} FROM stock WHERE idComponent={1};", nameCollum, id)))
            {
                if (result.Read())
                {
                    prevResult = result.GetInt32(nameCollum);
                }
            }
            updater.execute(String.Format("UPDATE stock SET {0}={1} WHERE idComponent={2};", nameCollum, new_value+prevResult, id));
        }
        public void updateDouble(string nameCollum, double new_value, int id)
        {
            updater.execute(String.Format("UPDATE stock SET {0}={1} WHERE idComponent={2};", nameCollum, new_value, id));
        }
        public string getStockString()
        {
            string result = "STOCKSTS&";
            using (MySqlDataReader reader = read("SELECT * FROM stock INNER JOIN component ON stock.idComponent = component.idComponent;")) {
                while(reader.Read())
                {
                    int idStock = reader.GetInt32("idStock");
                    int idComponent = reader.GetInt32(1);
                    int quantityInStock = reader.GetInt32("quantityInStock");
                    int quantityClient = reader.GetInt32("quantityClient");
                    int quantityOrder = reader.GetInt32("quantityOrder");
                    string desc = reader.GetString("description");

                    result += $"{idStock}/{idComponent}/{quantityInStock}/{quantityClient}/{quantityOrder}/{desc};";
                }
            }
            return result;
        }

        public List<int> getAllComponents()
        {
            List<int> ints = new List<int>();
            using (MySqlDataReader result = read("SELECT idComponent FROM stock;"))
            {
                while (result.Read())
                {
                    ints.Add(result.GetInt32("idComponent"));
                }
            }
            return ints;
        }

        public List<int> getAllStockIdsFromComponent(int componentId)
        {
            {
                List<int> ints = new List<int>();
                using (MySqlDataReader result = read($"SELECT idStock FROM stock WHERE idComponent={componentId};"))
                {
                    while (result.Read())
                    {
                        ints.Add(result.GetInt32("idStock"));
                    }
                }
                return ints;
            }
        }
    }
}

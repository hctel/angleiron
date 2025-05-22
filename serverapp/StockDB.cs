using System;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace backend
{
    public class StockDB : DatabaseConnector
    {
        public StockDB(string server, string databaseName, string username, string password) : base(server, databaseName, username, password)
        {
        }

        public MySqlDataReader getAllStock()
        {
            return read("SELECT * FROM stock;");
        }

        public MySqlDataReader getIdcomponent(int idcomponent)
        {
            return read(String.Format("SELECT * FROM stock WHERE idComponent={0};", idcomponent));
        }

        public MySqlDataReader getComponentInStock(int idcomponent, int quantity)
        {
            return read(String.Format("SELECT * FROM stock WHERE idComponent={0} AND Quantity > quantity ORDER BY price DESC;", idcomponent));
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
            execute(String.Format("INSERT INTO stock (idComponent, Quantity, QuantityClient, Quantity_order, supplier, Price, delivery_duration) VALUES ({0}, {1}, {2}, {3}, '{4}', {5}, {6});",
            idcomponent, quantity, quantityClient, quantity_order, supplier, price, deliveryDuration));
        }
        public void updateINT(string nameCollum, int new_value, int id)
        {
            execute(String.Format("UPDATE stock SET '{0}'={1} WHERE idComponent={2};", nameCollum, new_value, id));
        }
        public void updateDouble(string nameCollum, double new_value, int id)
        {
            execute(String.Format("UPDATE stock SET '{0}'={1} WHERE idComponent={2};", nameCollum, new_value, id));
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

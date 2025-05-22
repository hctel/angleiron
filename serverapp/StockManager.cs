// See https://aka.ms/new-console-template for more information


using MySql.Data.MySqlClient;

namespace backend
{
    public class StockManager
    {
        private StockDB stockDB;

        public StockManager(StockDB stockDB)
        {
            this.stockDB = stockDB;
        }

        public Dictionary<int, int> getClientQuantities()
        {
            using (MySqlDataReader result = stockDB.getAllStock())
            {
                Dictionary<int, int> clientQuantities = new Dictionary<int, int>();
                while (result.Read())
                {
                    int idComponent = result.GetInt32("idComponent");
                    int quantityClient = result.GetInt32("quantityClient");
                    clientQuantities.Add(idComponent, quantityClient);
                }
                return clientQuantities;
            }
        }

        public Dictionary<int, int> getOrderedQuantities()
        {
            using (MySqlDataReader result = stockDB.getAllStock())
            {
                Dictionary<int, int> orderedQuantities = new Dictionary<int, int>();
                while (result.Read())
                {
                    int idComponent = result.GetInt32("idComponent");
                    int quantityOrder = result.GetInt32("quantityOrder");
                    orderedQuantities.Add(idComponent, quantityOrder);
                }
                return orderedQuantities;
            }

        }

        public Dictionary<int, int> getStockQuantities()
        {
            using(MySqlDataReader result = stockDB.getAllStock())
            {
                Dictionary<int, int> stockQuantities = new Dictionary<int, int>();
                while (result.Read())
                {
                    int idComponent = result.GetInt32("idComponent");
                    int quantity = result.GetInt32("quantityInStock");
                    stockQuantities.Add(idComponent, quantity);
                }
                return stockQuantities;
            }
        }

        public int getStockDiff(int idComponent)
        {
            using (MySqlDataReader result = stockDB.getIdcomponent(idComponent))
            {
                if (result.Read()) return result.GetInt32("quantityClient") - result.GetInt32("quantityInStock");
            }
            return 0;
        }
    }
}
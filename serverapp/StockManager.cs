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
                    int idComponent = result.GetInt32("idStock");
                    int quantityClient = result.GetInt32("quantityClient");
                    if(clientQuantities.ContainsKey(idComponent))
                    {
                        clientQuantities[idComponent] += quantityClient;
                    }
                    else
                    {
                        clientQuantities.Add(idComponent, quantityClient);
                    }
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
                    int idComponent = result.GetInt32("idStock");
                    int quantityOrder = result.GetInt32("quantityOrder");
                    if(orderedQuantities.ContainsKey(idComponent))
                    {
                        orderedQuantities[idComponent] += quantityOrder;
                    }
                    else
                    {
                        orderedQuantities.Add(idComponent, quantityOrder);
                    }
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
                    int idComponent = result.GetInt32("idStock");
                    int quantity = result.GetInt32("quantityInStock");
                    if(stockQuantities.ContainsKey(idComponent))
                    {
                        stockQuantities[idComponent] += quantity;
                    }
                    else
                    {
                        stockQuantities.Add(idComponent, quantity);
                    }
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
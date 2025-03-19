using MySql.Data.MySqlClient;
using System;

namespace backend
{
    public class Stock
    {
        private Stock_DB stockDb;
        public Stock(Stock_DB stockDb)
        {
            this.stockDb = stockDb;
        }

        public int getClientQuantity(int idComponent)
        {
            List<int> stockIds = stockDb.getAllStockIdsFromComponent(idComponent);
            int quantity = 0;
            foreach (int stockId in stockIds)
            {
                using (MySqlDataReader result = stockDb.getStock(stockId))
                {
                    if (result.Read())
                    {
                        quantity += result.GetInt32("Quantity_client");
                    }
                }
            }
            return quantity;
        }

        public int getStockQuantity(int idComponent)
        {
            List<int> stockIds = stockDb.getAllStockIdsFromComponent(idComponent);
            int quantity = 0;
            foreach (int stockId in stockIds)
            {
                using (MySqlDataReader result = stockDb.getStock(stockId))
                {
                    if (result.Read())
                    {
                        quantity += result.GetInt32("Quantity");
                    }
                }
            }
            return quantity;
        }

        public int getOrderedQuantity(int idComponent)
        {
            List<int> stockIds = stockDb.getAllStockIdsFromComponent(idComponent);
            int quantity = 0;
            foreach (int stockId in stockIds)
            {
                using (MySqlDataReader result = stockDb.getStock(stockId))
                {
                    if (result.Read())
                    {
                        quantity += result.GetInt32("Quantity_order");
                    }
                }
            }
            return quantity;
        }

        ///<summary>Gets per-compoment client quantity</summary>
        public Dictionary<int, int> getClientQuantities()
        {
            List<int> ints = stockDb.getAllComponents();
            Dictionary<int, int> stocks = new Dictionary<int, int>();
            foreach (int id in ints)
            {
                stocks.Add(id, getClientQuantity(id));
            }
            return stocks;
        }

        ///<summary>Gets per-compoment stock quantity</summary>
        public Dictionary<int, int> getStockQuantities()
        {
            List<int> ints = stockDb.getAllComponents();
            Dictionary<int, int> stocks = new Dictionary<int, int>();
            foreach (int id in ints)
            {
                stocks.Add(id, getStockQuantity(id));
            }
            return stocks;
        }

        ///<summary>Gets per-compoment ordered quantity</summary>
        public Dictionary<int, int> getOrderedQuantities()
        {
            List<int> ints = stockDb.getAllComponents();
            Dictionary<int, int> stocks = new Dictionary<int, int>();
            foreach (int id in ints)
            {
                stocks.Add(id, getOrderedQuantity(id));
            }
            return stocks;
        }
    }
}

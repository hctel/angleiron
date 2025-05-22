using backend;
using MySql.Data.MySqlClient;
using ZstdSharp.Unsafe;

namespace backend
{
    class OrderManager
    {
        private OrderDB orderDB;
        private KitDB kitDB;
        private StockDB stockDB;

        public OrderManager(OrderDB orderDb, KitDB kitdb, StockDB stockdb)
        {
            this.orderDB = orderDb;
            this.kitDB = kitdb;
            this.stockDB = stockdb;
        }

        public List<List<string>> getOrders()
        {
            List<List<string>> orders = new List<List<string>>();
            int maxOrderId = orderDB.getLastId();
            for(int i = 1; i <= maxOrderId; i++)
            {
                using (MySqlDataReader reader = orderDB.getIdOrder(i))
                {
                    List<string> order = new List<string>();
                    bool inStock = true;
                    if (reader.Read())
                    {
                        order.Add(reader.GetInt16("idOrder").ToString());
                        order.Add(reader.GetString("name"));
                        order.Add(reader.GetString("status"));
                        order.Add(reader.GetDateTime("date").ToString("yyyy-MM-dd HH:mm:ss"));
                        do
                        {
                            if (reader.GetInt16("perCategory") > reader.GetInt32("inStock")) inStock = false;
                        } while (reader.Read());
                        order.Add(inStock.ToString());
                    }
                    

                    orders.Add(order);
                }

            }


            return orders;
        }

        public List<List<string>> detailOrder(int id)
        {
            List<List<string>> orderDetails = new List<List<string>>();
            using (MySqlDataReader reader = orderDB.getIdOrder(id))
            {
                if (reader.Read())
                {
                    do
                    {
                        List<string> orderDetail = new List<string>();
                        orderDetail.Add(reader.GetInt16("idComponent").ToString());
                        orderDetail.Add(reader.GetInt16("perCategory").ToString());
                        orderDetail.Add(reader.GetInt32("inStock").ToString());
                        orderDetail.Add(reader.GetString("description"));
                        orderDetails.Add(orderDetail);
                    } while (reader.Read());
                }
            }
            return orderDetails;
        }

        public void changeStatus(string v, int orderId)
        {
            if (v.Equals("COMPLETED"))
            {
                using (MySqlDataReader reader = orderDB.getIdOrder(orderId))
                {
                    if (reader.Read())
                    {
                        int category = reader.GetInt16("idCategory");
                        using (MySqlDataReader reader2 = kitDB.getKit(category))
                        {
                            while (reader2.Read())
                            {
                                int componentId = reader2.GetInt16("idComponent");
                                int count = reader2.GetInt32("perCategory");
                                using (MySqlDataReader stockReader = stockDB.getComponentInStock(componentId, count))
                                {
                                    if (stockReader.HasRows)
                                    {
                                        stockReader.Read();
                                        stockDB.updateINT("quantityInStock", stockReader.GetInt32("quantityInStock") - count, stockReader.GetInt32("idComponent"));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            orderDB.updateSTR("status", v, orderId);
        }

        public void deleteRow(int id)
        {
            orderDB.delete_row(id);
        }

        public void addOrder(int category, int client, string alreadyPaid, string status, double price, string color)
        {
            orderDB.addOrder(category, client, alreadyPaid, status, price, color);
            using (MySqlDataReader reader = kitDB.getKit(category))
            {
                while(reader.Read())
                {
                    int componentId = reader.GetInt16("idComponent");
                    int count = reader.GetInt32("perCategory");
                    using(MySqlDataReader stockReader = stockDB.getComponentInStock(componentId, count))
                    {
                        if(stockReader.HasRows)
                        {
                            reader.Read();
                            stockDB.updateINT("quantityClient", stockReader.GetInt32("quantityClient") + count, stockReader.GetInt32("idComponent"));
                            continue;
                        }
                    }
                    using(MySqlDataReader stockReader = stockDB.getComponents(componentId))
                    {
                        if (stockReader.HasRows)
                        {
                            reader.Read();
                            stockDB.updateINT("quantityClient", stockReader.GetInt32("quantityClient") + count, stockReader.GetInt32("idComponent"));
                            continue;
                        }
                    }
                }
            }
        }

    }
}
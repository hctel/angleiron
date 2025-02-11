using MySql.Data.MySqlClient;
using System;

namespace backend {
    public class Stock_calculation : DatabaseConnector
    {
        private int not_in_stock;
        private int to_order;
        public Stock_calculation(string server, string databaseName, string username, string password):base(server, databaseName, username, password)
        {
            
        }
    }
}
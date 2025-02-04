using System;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace backend
{
    public class DatabaseConnector
    {
        private MySqlConnection connection;
        public DatabaseConnector(string server, string databaseName, string username, string password)
        {
            string connstring = string.Format("Server={0}; database={1}; UID={2}; password={3}", server, databaseName, username, password);
            connection = new MySqlConnection(connstring);
            connection.Open();
        }

        public bool isOpen()
        {
            return connection.State == System.Data.ConnectionState.Open;
        }

        public MySqlDataReader read(string query) {
            return new MySqlCommand(query, connection).ExecuteReader();
        }

        public bool execute(string query)
        {
            return new MySqlCommand(query, connection).ExecuteNonQuery() != 0;
        }

        
    }
}


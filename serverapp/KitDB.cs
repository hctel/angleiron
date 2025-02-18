using System;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace backend
{
    public class KitDB : DatabaseConnector
    {
        public KitDB(string server, string databaseName, string username, string password) : base(server, databaseName, username, password)
        {
        }

        public MySqlDataReader getIdcategory(int idcategory)
        {
          return read(String.Format("SELECT * FROM table_categories WHERE id_category={0};", idcategory));
        }

        public void addOrder(string dimension, string colors_available, string options_available)
        {
            execute(String.Format("INSERT INTO table_categories (Dimension, Colors_available, Options_available) VALUES ('{0}', '{1}', '{2}');", 
            dimension, colors_available, options_available));
        }
    }
}
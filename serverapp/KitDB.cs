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

        public List<int> getAllIDs()
        {
            using (MySqlDataReader reader = read("SELECT idCategory FROM categories;"))
            {
                List<int> ids = new List<int>();
                while (reader.Read())
                {
                    ids.Add(reader.GetInt32("idCategory"));
                }
                return ids;
            }
        }
           
        public MySqlDataReader getIdcategory(int idcategory)
        {
          return read(String.Format("SELECT * FROM categories WHERE idCategory={0};", idcategory));
        }

        public void addKit(string dimension, string colors_available, string options_available)
        {
            execute(String.Format("INSERT INTO categories (dimension, colorsAvail, optionsAvail) VALUES ('{0}', '{1}', '{2}');", 
            dimension, colors_available, options_available));
        }

    }
}
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

        public List<Kit> getAllKits()
        {
            List<Kit> kits = new List<Kit>();
            using (MySqlDataReader reader = read("SELECT * FROM categories;"))
            {
                while (reader.Read())
                {
                    Kit kit = new Kit(reader.GetInt32("idCategory"), reader.GetString("name"), reader.GetString("dimension"), reader.GetDouble("price"), reader.GetString("colorsAvail"), reader.GetString("optionsAvail"), reader.GetString("imageName"));
                    kits.Add(kit);
                }
            }
            return kits;
        }

        public MySqlDataReader getKit(int idcategory)
        {
          return read(String.Format("SELECT * FROM categories JOIN componentCategory ON categories.idCategory = componentCategory.idCategory WHERE categories.idCategory={0};", idcategory));
        }

        public void addKit(string dimension, string colors_available, string options_available)
        {
            execute(String.Format("INSERT INTO categories (dimension, colorsAvail, optionsAvail) VALUES ('{0}', '{1}', '{2}');", 
            dimension, colors_available, options_available));
        }

    }
}
using System;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace backend
{
    public class KIT_to_component : DatabaseConnector
    {
        public KIT_to_component(string server, string databaseName, string username, string password) : base(server, databaseName, username, password)
        {
        }

        public MySqlDataReader getIdcategory(int idcategory)
        {
          return read(String.Format("SELECT * FROM component_type WHERE id_category={0};", idcategory));
        }

        public void addOrder(int id_component, int id_category, int numbercategory)
        {
            execute(String.Format("INSERT INTO component_type (id_component, id_category, numberpercategory) VALUES ({0}, {1}, {2});", 
            id_component, id_category, numbercategory));
        }
    }
}
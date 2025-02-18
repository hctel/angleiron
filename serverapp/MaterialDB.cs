using System;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace backend
{
    public class MaterialDB : DatabaseConnector
    {
        public MaterialDB(string server, string databaseName, string username, string password) : base(server, databaseName, username, password)
        {
        }

        public MySqlDataReader getIdcomposant(int idcomponent)
        {
          return read(String.Format("SELECT * FROM component WHERE id_component={0};", idcomponent));
        }

        public void addMaterial(int idcomponent, string description)
        {
            execute(String.Format("INSERT INTO component ( id_component, Description) VALUES ({0}, '{1}');", 
            idcomponent, description));
        }
    }
}
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

        public MySqlDataReader getIdcomponent(int idcomponent)
        {
          return read(String.Format("SELECT * FROM component WHERE idComponent={0};", idcomponent));
        }

        public void addMaterial(int idcomponent, string description)
        {
            execute(String.Format("INSERT INTO component ( idComponent, description) VALUES ({0}, '{1}');", 
            idcomponent, description));
        }
    }
    //test1212

}
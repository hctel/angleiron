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

        public MySqlDataReader getIdcomposant(int idcomposant)
        {
          return read(String.Format("SELECT * FROM Stock WHERE id_composant={0};", idcomposant));
        }

        public void addOrder(int idcomposant, string description)
        {
            execute(String.Format("INSERT INTO commandes ( id_composant, Description) VALUES ({0}, '{1}');", 
            idcomposant, description));
        }
    }
}
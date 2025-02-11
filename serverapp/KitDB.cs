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

        public MySqlDataReader getIdcomposant(int idcategory)
        {
          return read(String.Format("SELECT * FROM Stock WHERE id_category={0};", idcategory));
        }

        public void addOrder(int idcomposant, int id_client, int déja_payé, int statut, int prix)
        {
            execute(String.Format("INSERT INTO commandes (id_client, Dimension, Couleurs_, Déja_payé, Statut) VALUES ({0}, {1}, {2}, {3}, {4});", 
            id_client, idcomposant, prix, déja_payé,statut));
        }
    }
}
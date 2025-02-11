using System;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace backend
{
    public class Order_DB : DatabaseConnector
    {
        public Order_DB(string server, string databaseName, string username, string password) : base(server, databaseName, username, password)
        {
        }

        public MySqlDataReader getIdcomposant(int idcomposant)
        {
          return read(String.Format("SELECT * FROM Stock WHERE id_composant={0};", idcomposant));
        }

        public void addOrder(int idcomposant, int id_client, int déja_payé, int statut, int prix)
        {
            execute(String.Format("INSERT INTO commandes (id_client, id_composant, Prix, Déja_payé, Statut) VALUES ({0}, {1}, {2}, {3}, {4});", 
            id_client, idcomposant, prix, déja_payé,statut));
        }
    }
}
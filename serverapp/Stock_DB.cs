using System;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace backend
{
    public class Stock_DB : DatabaseConnector
    {
        public Stock_DB(string server, string databaseName, string username, string password) : base(server, databaseName, username, password)
        {
        }

        public MySqlDataReader getIdcomposant(int idcomposant)
        {
          return read(String.Format("SELECT * FROM Stock WHERE id_composant={0};", idcomposant));
        }

        public void addStock(string fournisseur, int idcomposant, int quantité, int quantité_client, int quantité_commendé, int prix, int durée_livraison)
        {
            execute(String.Format("INSERT INTO Stock (id_composant, Quantité, Quantité_client, Quantité_commandée, Fournisseur, Prix, Durée_de_livraison) VALUES ({0}, {1}, {2}, {3}, '{4}', {5}, {6});", 
            idcomposant, quantité, quantité_client,quantité_commendé,fournisseur,prix,durée_livraison));
        }
    }
}

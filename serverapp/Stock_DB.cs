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

        public MySqlDataReader getIdcomponent(int idcomponent)
        {
          return read(String.Format("SELECT * FROM Stock WHERE id_component={0};", idcomponent));
        }

        public void addStock(string fournisseur, int idcomponent, int quantité, int quantité_client, int quantité_commendé, int prix, int durée_livraison)
        {
            execute(String.Format("INSERT INTO Stock (id_component, Quantité, Quantité_client, Quantité_commandée, Fournisseur, Prix, Durée_de_livraison) VALUES ({0}, {1}, {2}, {3}, '{4}', {5}, {6});", 
            idcomponent, quantité, quantité_client,quantité_commendé,fournisseur,prix,durée_livraison));
        }
        public void updateINT(string name_collum, int new_value, int id){
            execute(String.Format("UPDATE Stock SET '{0}'={1} WHERE id_component={2};",name_collum, new_value, id));
        }
    }
}

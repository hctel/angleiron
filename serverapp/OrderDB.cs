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

        public MySqlDataReader getIdOrder(int idorder)
        {
          return read(String.Format("SELECT * FROM orders WHERE idorder={0};", idorder));
        }
        public MySqlDataReader getOrder()
        {
          return read(String.Format("SELECT * FROM orders ;"));
        }
        public int getLastId(){
            using(MySqlDataReader reader = read("SELECT idorder FROM ordrers ORDER BY idorder DESC LIMIT 1;")){
                if(reader.Read()){
                    return reader.GetInt32(0);
                }
                return 1;
            }
        }

        public void addOrder(int idcategory, int id_client, string already_paid, string status, double price)
        {
            execute(String.Format("INSERT INTO orders (id_client, id_category, Price, Already_paid, Status) VALUES ({0}, {1}, {2}, '{3}', '{4}');", 
            id_client, idcategory, price, already_paid,status));
        }
        public void updateSTR(string name_collum, string new_value, int id){
            execute(String.Format("UPDATE orders SET '{0}'='{1}' WHERE idorder={2};",name_collum, new_value, id));
        }
        public void delete_row(int id){
            execute(String.Format("DELETE FROM orders WHERE idorder={0};", id));
        }
    }
}
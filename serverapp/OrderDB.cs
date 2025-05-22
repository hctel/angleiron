using System;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace backend
{
    public class OrderDB : DatabaseConnector
    {
        public OrderDB(string server, string databaseName, string username, string password) : base(server, databaseName, username, password)
        {
        }

        public MySqlDataReader getIdOrder(int idorder)
        {
          return read(String.Format("SELECT * FROM orders INNER JOIN componentCategory ON orders.idCategory = componentCategory.idCategory INNER JOIN component ON componentCategory.idComponent = component.idComponent INNER JOIN clients ON orders.idClient = clients.idClient WHERE idOrder = {0};", idorder));
        }
        public MySqlDataReader getOrder()
        {
          return read(String.Format("SELECT * FROM orders;"));
        }
        public int getLastId(){
            using(MySqlDataReader reader = read("SELECT idOrder FROM orders ORDER BY idOrder DESC LIMIT 1;")){
                if(reader.Read()){
                    return reader.GetInt32(0);
                }
                return 1;
            }
        }

        public void addOrder(int idcategory, int id_client, string already_paid, string status, double price, string color)
        {
            execute(String.Format("INSERT INTO orders (idClient, idCategory, price, alreadyPaid, status, color) VALUES ({0}, {1}, {2}, '{3}', '{4}', '{5}');", 
            id_client, idcategory, price, already_paid,status, color));
        }
        public void updateSTR(string nameColumn, string newValue, int id){
            execute(String.Format("UPDATE orders SET {0}='{1}' WHERE idOrder={2};",nameColumn, newValue, id));
        }
        public void delete_row(int id){
            execute(String.Format("DELETE FROM orders WHERE idOrder={0};", id));
        }
    }
}
using MySql.Data.MySqlClient;
using System;

namespace backend {
    public class Stock_calculation 
    {
        private Stock_DB database;
        private int not_in_stock;
        private int to_order;
        public Stock_calculation(Stock_DB database)
        {
            this.database=database;
        }
        public void check(int id_composant){
            MySqlDataReader result = database.getIdcomponent(id_composant);
            if(result.Read()){
                int delta_stock_need=0;
                delta_stock_need = result.GetInt32("Quantité")-result.GetInt32("Quantité_client");
                not_in_stock = delta_stock_need;
                delta_stock_need += result.GetInt32("Quantité_commandée");
                to_order = delta_stock_need;
            }
        }
        public int get_not_in_stock(){
            return not_in_stock;
        }
        public int get_to_order(){
            return to_order;
        }
    }
}
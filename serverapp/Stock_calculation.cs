using MySql.Data.MySqlClient;
using Org.BouncyCastle.Math.EC;
using System;

namespace backend {
    public class Stock_calculation 
    {
        private Stock_DB database;
        private int not_in_stock;
        private int to_order;
        private int delta_stock_need;
        public Stock_calculation(Stock_DB database)
        {
            this.database=database;
        }
        public void check(int id_component){
            using(MySqlDataReader result = database.getIdcomponent(id_component)){
                if(result.Read()){
                    int delta_stock_need=0;
                    delta_stock_need = result.GetInt32("Quantity")-result.GetInt32("Quantity_client");
                    delta_stock_need += result.GetInt32("Quantity_order");
                    if(delta_stock_need>0){
                        to_order=0;
                    }
                    else {
                        
                        to_order =  Math.Abs(delta_stock_need);
                    }
                }
            }
        }
        public bool get_not_in_stock(){
            return delta_stock_need < 1;
        }
        public int get_to_order(){
            return to_order;
        }
        public void updateInt(string name_collum, int new_value, int id){
            database.updateINT(name_collum, new_value, id);
        }
        public void updateDouble(string name_collum, double new_value, int id){
            database.updateDouble(name_collum, new_value, id);
        }

    }
}
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg;
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
                    int delta_stock_need = result.GetInt32("Quantity")-result.GetInt32("Quantity_client");
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
        public int getlowestprice(int id_component){
            int id_stock = 0;
            using(MySqlDataReader result = database.getIdcomponent(id_component)){
                int lowestprice = 0;
                while(result.Read()){
                    if(lowestprice==0){
                        lowestprice = result.GetInt32("Price");
                        id_stock = result.GetInt32("id_stock");
                    }
                    else if(result.GetInt32("Price")<lowestprice)
                    {
                        id_stock = result.GetInt32("id_stock");
                        }
                }
            }
            return id_stock;
        }

    }
}
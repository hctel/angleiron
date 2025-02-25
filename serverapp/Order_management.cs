using MySql.Data.MySqlClient;
using Mysqlx.Resultset;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Asn1.Misc;
using System;

namespace backend {
    public class Order_management {
        private Order_DB order_DB;
        private Stock_DB stock_DB;
        private KIT_to_component kIT_To_Component;
        public Order_management(Order_DB order_DB, Stock_DB stock_DB, KitDB kitDB, MaterialDB materialDB, KIT_to_component kIT_To_Component) {
            this.order_DB=order_DB;
            this.stock_DB=stock_DB;
            this.kIT_To_Component=kIT_To_Component;
        }
        public void management(int idorder){
            MySqlDataReader resultOrder = order_DB.getIdOrder(idorder);
            resultOrder.Read();
            int id_category = resultOrder.GetInt32("id_category");
            MySqlDataReader resultcomponent_type = kIT_To_Component.getIdcategory(id_category);
            while (resultcomponent_type.Read()) {
                int id_component = resultcomponent_type.GetInt32("id_component");
                MySqlDataReader resultStock = stock_DB.getIdcomponent(id_component);
                resultStock.Read();
                int newQuantiyclient = resultStock.GetInt32("Quantity_client")+resultcomponent_type.GetInt32("numberpercategory");
                stock_DB.updateINT("Quantity_client", newQuantiyclient, id_component); 
            } 
        }
        public void add_order(int idcategory, int id_client, string already_paid, string status, int price){
            order_DB.addOrder(idcategory, id_client,already_paid, status, price);
        }
        public string get_status(int idorder){
            string result;
            MySqlDataReader row = order_DB.getIdOrder(idorder);
            row.Read();
            result = row.GetString("status");
            return result;
        }
        public string get_already_paid(int idorder){
            string result;
            MySqlDataReader row = order_DB.getIdOrder(idorder);
            row.Read();
            result = row.GetString("Already_paid");
            return result;
        }
        public List<List<string>> get_orders(){
            List<List<string>> result = new List<List<string>>();
            MySqlDataReader row = order_DB.getOrder();
            while(row.Read()){
                List<string> row_result = new List<string>();
                row_result.Add(row.GetInt32("idorder") + "");
                row_result.Add(row.GetInt32("id_client") + "");
                row_result.Add(row.GetInt32("id_category") + "");
                row_result.Add(row.GetDouble("Price") + "");
                row_result.Add(row.GetString("Already_paid"));
                row_result.Add(row.GetString("Status"));
                result.Add(row_result);
            }
            return result;
        }
        public List<List<string>> detail_order(int idorder){
            List<List<string>> result = new List<List<string>>();
            MySqlDataReader row = order_DB.getIdOrder(idorder);
            row.Read();
            int id_category = row.GetInt32("id_category");
            MySqlDataReader resultcomponent_type = kIT_To_Component.getIdcategory(id_category);
            while (resultcomponent_type.Read()) {
                List<string> row_result = new List<string>();
                int id_component
                result.Add(row_result);
            }
            
            
            return result;
        }
        public void change_satus(string new_satus, int idorder){
        order_DB.updateSTR("Status", new_satus, idorder);
    }

    }
    






}
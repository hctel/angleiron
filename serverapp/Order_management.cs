using MySql.Data.MySqlClient;
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
            int id_category = resultOrder.GetInt32("id_category");
            MySqlDataReader resultcomponent_type = kIT_To_Component.getIdcategory(id_category);
            while (resultcomponent_type.Read()) {
                int id_component = resultcomponent_type.GetInt32("id_component");
                MySqlDataReader resultStock = stock_DB.getIdcomponent(id_component);
                int newQuantiyclient = resultStock.GetInt32("Quantity_client")+resultcomponent_type.GetInt32("numberpercategory");
                stock_DB.updateINT("Quantity_client", newQuantiyclient, id_component);
                
            }
            
        }
    }







}
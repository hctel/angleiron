using MySql.Data.MySqlClient;
using Mysqlx.Resultset;
using MySqlX.XDevAPI.Common;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Asn1.Misc;
using System;
using System.Data;
using System.Diagnostics;

namespace backend
{
    public class Order_management
    {
        private Order_DB order_DB;
        private Stock_DB stock_DB;
        private Stock_calculation stock_calculation;
        private MaterialDB materialDB;
        private KIT_to_component kIT_To_Component;
        private UserDB userDB;
        private UserAuth userAuth;
        public Order_management(Order_DB order_DB, Stock_DB stock_DB, KitDB kitDB, MaterialDB materialDB, KIT_to_component kIT_To_Component, Stock_calculation stock_calculation, UserDB userDB, UserAuth userAuth)
        {
            this.order_DB = order_DB;
            this.stock_DB = stock_DB;
            this.kIT_To_Component = kIT_To_Component;
            this.materialDB = materialDB;
            this.stock_calculation = stock_calculation;
            this.userDB = userDB;
            this.userAuth = userAuth;
        }
        public void management()
        {
            int idorder= order_DB.getLastId();
            try
            {   
                using (MySqlDataReader resultOrder = order_DB.getIdOrder(idorder))
                {
                    if (resultOrder.HasRows && resultOrder.Read())
                    {
                        int id_category = resultOrder.GetInt32("id_category");

                        using (MySqlDataReader resultcomponent_type = kIT_To_Component.getIdcategory(id_category))
                        {
                            while (resultcomponent_type.Read())
                            {
                                int id_component = resultcomponent_type.GetInt32("id_component");

                                using (MySqlDataReader resultStock = stock_DB.getIdcomponent(id_component))
                                {
                                    if (resultStock.HasRows && resultStock.Read())
                                    {
                                        int quantityClient = resultStock.GetInt32("Quantity_client");
                                        int numberPerCategory = resultcomponent_type.GetInt32("numberpercategory");
                                        int newQuantityClient = quantityClient + numberPerCategory;

                                        stock_DB.updateINT("Quantity_client", newQuantityClient, id_component);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Aucune commande trouvée avec l'ID {idorder}.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du traitement de l'ordre {idorder} : {ex.Message}");
            }
        }

        public void add_order(int idcategory, int id_client, string already_paid, string status, double price, string color)
        {
            order_DB.addOrder(idcategory, id_client, already_paid, status, price, color);
        }
        public string get_status(int idorder)
        {
            string result;
            using (MySqlDataReader row = order_DB.getIdOrder(idorder))
            {
                row.Read();
                result = row.GetString("status");
            }
            return result;
        }
        public string get_already_paid(int idorder)
        {
            string result;
            using (MySqlDataReader row = order_DB.getIdOrder(idorder))
            {
                row.Read();
                result = row.GetString("Already_paid");
            }
            return result;
        }
        public List<List<string>> get_orders()
        {

            List<List<string>> result = new List<List<string>>();
            List<int> ids = new List<int>();

            try
            {
                using (MySqlDataReader row = order_DB.getOrder())
                {
                    if (row.HasRows)
                    {
                        while (row.Read())
                        {
                            List<string> row_result = new List<string>();
                            int id_client = row.GetInt32("id_client");
                            using (MySqlDataReader resultUser = userDB.getUserFromId(id_client))
                            {
                                if(resultUser.Read()){
                                    string name = resultUser.GetString("Name");
                                    row_result.Add(name);
                                }
                            }
                            row_result.Add(row.GetInt32("idorder") + "");;
                            row_result.Add(row.GetString("Status"));
                            row_result.Add(row.GetDateTime("date").ToString("dd-MM-yyy"));
                            int id_order = row.GetInt32("idorder");
                            ids.Add(id_order);
                            result.Add(row_result);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Aucune commande trouvée.");
                    }
                }
                for(int i = 0; i < ids.Count; i++)
                {
                    int id_order = ids[i];
                    List<List<string>> detailorder = detail_order(id_order);
                    string res = "0";
                    foreach (List<string> detail in detailorder)
                    {
                        if (Int32.Parse(detail[2]) - Int32.Parse(detail[1]) > 0)
                        {
                            res = "1";
                        }
                        else
                        {
                            res = "0";
                        }
                    }
                    result[i].Add(res);
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération des commandes : {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }

            return result;
        }


        public List<List<string>> detail_order(int idorder)
        {
            List<List<string>> result = new List<List<string>>();
            using (MySqlDataReader row = order_DB.getIdOrder(idorder))
            {
                if(row.Read())
                {
                    int id_category = row.GetInt32("id_category");
                    using (MySqlDataReader resultcomponent_type = kIT_To_Component.getIdcategory(id_category))
                    {
                        while (resultcomponent_type.Read())
                        {
                            List<string> row_result = new List<string>();
                            int id_component = resultcomponent_type.GetInt32("id_component");
                            row_result.Add(id_component + "");
                            using (MySqlDataReader resultStock = stock_DB.getIdcomponent(id_component))
                            {
                                resultStock.Read();
                                row_result.Add(resultStock.GetInt32("Quantity_client") + "");
                                row_result.Add(resultStock.GetInt32("Quantity") + "");
                            }
                            using (MySqlDataReader material = materialDB.getIdcomponent(id_component))
                            {
                                if (material.Read())
                                {
                                    row_result.Add(material.GetString("Description"));
                                    result.Add(row_result);
                                }
                            }
                        }
                    }
                } 
            }


            return result;
        }
        public void change_satus(string new_satus, int idorder)
        {
            order_DB.updateSTR("Status", new_satus, idorder);
        }
        public void delete_row(int idorder)
        {
            order_DB.delete_row(idorder);
        }

    }
}
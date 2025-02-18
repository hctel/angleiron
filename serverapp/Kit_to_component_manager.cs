using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;

namespace backend{
    public class Kit_to_component_manager {
        private KIT_to_component database;
        public Kit_to_component_manager(KIT_to_component dB) {
            this.database = dB;
        }
        public void new_kit_to_component(int id_component, int id_category, int numbercategory){
            database.addLink(id_component, id_category, numbercategory);
        }
    }
}
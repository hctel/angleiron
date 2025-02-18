using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;

namespace backend{
    public class Kit_manager {
        private KitDB kitDB;
        public Kit_manager(KitDB dB) {
            this.kitDB = dB;
        }
        public void new_kit(string dimension, string colors_available, string options_available){
            kitDB.addKit(dimension, colors_available,options_available);
        }
    }
}
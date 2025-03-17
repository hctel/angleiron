using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;

namespace backend{

    public class Kit
    {
        public int id { get; }
        public string name { get; }
        public string dimension { get; }
        public double price { get; }
        public string colors_available { get; }
        public string options_available { get; }
        public string image { get; }

        public Kit(int id, string name, string dimension, double price, string colors_available, string options_available, string image)
        {
            this.id = id;
            this.name = name;
            this.dimension = dimension;
            this.price = price;
            this.colors_available = colors_available;
            this.options_available = options_available;
            this.image = image;
        }

        public override string ToString()
        {
            return $"{id}/{name}/{dimension}/{price}/{colors_available}/{options_available}/{image}";
        }
    }
        public class Kit_manager {
        private KitDB kitDB;
        public Kit_manager(KitDB dB) {
            this.kitDB = dB;
        }
        public void new_kit(string dimension, string colors_available, string options_available){
            kitDB.addKit(dimension, colors_available,options_available);
        }

        public List<Kit> getKits()
        {
            List<Kit> kits = new List<Kit>();
            foreach(int i in kitDB.getAllIDs()) {
                using(MySqlDataReader reader = kitDB.getIdcategory(i))
                {
                    if (reader.Read())
                    {
                        kits.Add(new Kit(reader.GetInt32("id_category"),reader.GetString("Name"), reader.GetString("Dimension"), reader.GetDouble("Price"), reader.GetString("Colors_available"), reader.GetString("Options_available"), reader.GetString("ImageName")));
                    }
                }
            }
            return kits;
        }
    }
}
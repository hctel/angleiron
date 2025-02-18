using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;

namespace backend{
    public class Material_manager {
        private MaterialDB material;
        public Material_manager(MaterialDB dB) {
            this.material = dB;
        }
        public void new_material(int idcomponent, string description){
            material.addMaterial(idcomponent,description);
        }
    }
}
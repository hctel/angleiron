using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace merchandapp
{
    //internal class CommandeList
    //{
    //    public  List<Commande> commandes;
        

    //}

    internal class Commande
    {
        public int id;
        public string name;
        public string status;
        public string date;
        public bool inStock;


        public Commande(int id, string name, string status, string date, bool instock)
        {
            this.id = id;
            this.name = name;
            this.status = status;
            this.date = date;
            this.inStock = instock;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace merchandapp
{
    internal class CommandeList
    {
        List<Commande> commandes;
    }

    internal class Commande
    {
        int id;
        string name;
        string status;
        string date;
        bool inStock;


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
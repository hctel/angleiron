using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace merchandapp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        public class Commande
        {
            public int id { get; set; }
            public string name { get; set; }
            public string status { get; set; }
            public string date { get; set; }
            public bool inStock { get; set; }


            /*public Commande(int id, string name, string status, string date, bool instock)
            {
                this.id = id;
                this.name = name;
                this.status = status;
                this.date = date;
                this.inStock = instock;
            }*/
        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void commandeBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}

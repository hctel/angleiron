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
        List<Panel> listPanel = new List<Panel>();
        int index = 1;

        //public BindingList<OrderSummary> orderSummaries = new BindingList<OrderSummary>();
        List<OrderSummary> orderSummaries = new List<OrderSummary>()
        {
            new OrderSummary { orderID = 5, orderName="hello"},
            new OrderSummary { orderID = 8, orderName="world"},
        };
        BindingList<OrderSummary> bindingList;
        BindingSource source;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listPanel.Add(panel1);
            listPanel.Add(panel2);
            listPanel[index].BringToFront();

            bindingList = new BindingList<OrderSummary>(orderSummaries);
            source = new BindingSource(bindingList, null);
            this.OrdersDataGridView.DataSource = source;

            //orderSummaries.Add(new OrderSummary("5", "test", "ok", "24/04", "nope"));
            //orderSummaries.Add(new OrderSummary("4", "2test", "pas ok", "25/04", "nope"));

            source.Add(new OrderSummary { orderID = 9, orderName = "hell6o" });
            source.Add(new OrderSummary("1", "after", "pas ok", "25/04", "nope"));

            //var bindingList = new BindingList<OrderSummary>(orderSummaries);
            //var source = new BindingSource(bindingList, null);
            //this.dataGridView1.DataSource = source;

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

        private void dataGridView1_CellContentClick_3(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            index = 0;
            listPanel[index].BringToFront();
            //((Button)sender).Text = index.ToString();
        }

        private void PartListDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void completeButton_Click(object sender, EventArgs e)
        {

        }
    }
}

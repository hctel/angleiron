using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//#define VIEW_BUTTON_COLUMN_INDEX 

namespace merchandapp
{
    public partial class Form1 : Form
    {
        const int VIEW_BUTTON_COLUMN_INDEX = 5;
        List<Panel> listPanel = new List<Panel>();
        int index = 1;
        Network network;

        List<OrderSummary> orderSummaries = new List<OrderSummary>();
        BindingList<OrderSummary> orderSummariesBindingList;
        BindingSource orderSummariesSource;

        List<OrderSummary> orderParts = new List<OrderSummary>();
        BindingList<OrderSummary> orderPartsBindingList;
        BindingSource orderPartsSource;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Panels / Pages
            listPanel.Add(panel1);
            listPanel.Add(panel2);
            listPanel[index].BringToFront();

            // Bindings
            orderSummariesBindingList = new BindingList<OrderSummary>(orderSummaries);
            orderSummariesSource = new BindingSource(orderSummariesBindingList, null);
            this.OrdersDataGridView.DataSource = orderSummariesSource;

            orderPartsBindingList = new BindingList<OrderSummary>(orderSummaries);
            orderPartsSource = new BindingSource(orderPartsBindingList, null);
            this.PartListDataGridView.DataSource = orderPartsSource;

            orderSummariesSource.Add(new OrderSummary { orderID = 9, orderName = "hell6o" });
            orderSummariesSource.Add(new OrderSummary("1", "after", "pas ok", "25/04", "nope"));

            network = new Network("172.17.35.22", 80);
            //Debug.WriteLine(network.getOrders().ToString());
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
            if (e.ColumnIndex == VIEW_BUTTON_COLUMN_INDEX)
            {
                
                network.getOrderDetails(e.RowIndex+1);
                listPanel[1].BringToFront();
                Debug.WriteLine(network.getOrderDetails(e.RowIndex));
            }
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

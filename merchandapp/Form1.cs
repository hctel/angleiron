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
        int index = 0;
        Network network;

        List<OrderSummary> orderSummaries = new List<OrderSummary>();
        BindingList<OrderSummary> orderSummariesBindingList;
        BindingSource orderSummariesSource;

        List<OrderPart> orderParts = new List<OrderPart>();
        BindingList<OrderPart> orderPartsBindingList;
        BindingSource orderPartsSource;
        Order currentOrder;

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

            orderPartsBindingList = new BindingList<OrderPart>(orderParts);
            orderPartsSource = new BindingSource(orderPartsBindingList, null);
            this.PartListDataGridView.DataSource = orderPartsSource;

            network = new Network("172.17.33.231", 80);
            Debug.WriteLine(network.getOrders().ToString());

            foreach (OrderSummary order in network.getOrders())
            { orderSummariesSource.Add(order); }

            /*PartListDataGridView.ReadOnly = false;
            for (int i = 0; i < PartListDataGridView.ColumnCount; i++)
            { PartListDataGridView.Columns[i].ReadOnly = true; }
            PartListDataGridView.Columns[4].ReadOnly = true;*/
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
                currentOrder = network.getOrderDetails(e.RowIndex + 1);
                Debug.WriteLine(currentOrder);
                if (currentOrder != null)
                {
                    foreach (OrderPart item in currentOrder.parts)
                    {
                        orderPartsSource.Add(item);
                    }
                    listPanel[1].BringToFront();
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            index = 0;
            orderSummariesSource.Clear();
            foreach (OrderSummary order in network.getOrders())
            { orderSummariesSource.Add(order); }
            listPanel[index].BringToFront();
            orderPartsSource.Clear();
            //((Button)sender).Text = index.ToString();
        }

        private void PartListDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void completeButton_Click(object sender, EventArgs e)
        {
            network.updateStatus(currentOrder.orderID);
            Debug.WriteLine(currentOrder.orderID);
        }
    }
}

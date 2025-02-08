using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clientapp
{
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
            this.Size = new Size(1280, 720);
            this.MinimumSize = new Size(1280, 720);
            this.MaximumSize = new Size(1280, 720);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SaveForLaterButton.BackColor = Color.FromArgb(94, 176, 87);
            this.SaveForLaterButton.ForeColor = Color.White;
            this.SaveForLaterButton.FlatStyle = FlatStyle.Flat;
            this.SaveForLaterButton.FlatAppearance.BorderSize = 0;
            this.SaveForLaterButton.Size = new Size(200, 50);
            this.SaveForLaterButton.Location = new Point(this.Width - 375, this.Height - 125);

            this.OrderButton.BackColor = Color.FromArgb(243, 187, 78);
            this.OrderButton.ForeColor = Color.White;
            this.OrderButton.FlatStyle = FlatStyle.Flat;
            this.OrderButton.FlatAppearance.BorderSize = 0;
            this.OrderButton.Size = new Size(100, 50);
            this.OrderButton.Location = new Point(this.Width - 150, this.Height - 125);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            this.panel1.Size = new Size(this.Width, 75);
            this.panel1.BackColor = Color.FromArgb(0, 168, 232);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            this.panel2.Size = new Size(this.Width, 120);
            this.panel2.Location = new Point(0, this.Height - 160);
            this.panel2.BackColor = Color.FromArgb(0, 168, 232);
        }

        private void lockerPanel_Paint(object sender, PaintEventArgs e)
        {
            this.lockersPanel.Size = new Size(300, 490);
            this.lockersPanel.Location = new Point(0, 70);
            //this.lockersPanel.BackColor = Color.FromArgb(236, 236, 235);
            this.lockersPanel.BackColor = Color.FromArgb(255, 69, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {

        }

        private void SummaryPanel_Paint(object sender, PaintEventArgs e)
        {
            this.SummaryPanel.Size = new Size(300, 490);
            this.SummaryPanel.BackColor = Color.FromArgb(0, 128, 0);
            this.SummaryPanel.Location = new Point(this.Width-300, 70);
        }
    }
}

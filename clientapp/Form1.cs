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
    }
}

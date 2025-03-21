namespace ClientAppRemake
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(1920, 1080);
            this.MinimumSize = new Size(1920, 1080);
            this.MaximumSize = new Size(1920, 1080);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "AngleIron V2";
            this.MaximizeBox = false;

            this.Load += new EventHandler(Form1_Load);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Panel headerPanel = new Panel();
            headerPanel.Size = new Size(1920, 160);
            headerPanel.BackColor = Color.FromArgb(0, 168, 232);
            headerPanel.Location = new Point(0, 0);
            this.Controls.Add(headerPanel);
        }
    }
}

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
            //Header Panel
            Panel headerPanel = new Panel();
            headerPanel.Size = new Size(1920, 160);
            headerPanel.BackColor = Color.FromArgb(0, 168, 232);
            headerPanel.Location = new Point(0, 0);
            this.Controls.Add(headerPanel);

            headerPanel.Controls.Add(new Label
            {
                Text = "AngleIron V2",
                Font = new Font("Arial", 24, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(10, 35),
                AutoSize = true
            });

            //Footer Panel
            Panel footerPanel = new Panel();
            footerPanel.Size = new Size(1920, 160);
            footerPanel.BackColor = Color.FromArgb(0, 168, 232);
            footerPanel.Location = new Point(0, this.ClientSize.Height - footerPanel.Height);
            this.Controls.Add(footerPanel);

            //Main Panel
            Panel mainPanel = new Panel();
            mainPanel.Size = new Size(1920, 1080 - headerPanel.Height - footerPanel.Height);
            mainPanel.BackColor = Color.FromArgb(255, 255, 255);
            mainPanel.Location = new Point(0, headerPanel.Height);
            this.Controls.Add(mainPanel);

            //Selection Panel
            Panel selectionPanel = new Panel();
            selectionPanel.Size = new Size(450, mainPanel.Height);
            selectionPanel.BackColor = Color.FromArgb(0, 0, 232);
            selectionPanel.Location = new Point(0, 0); 
            mainPanel.Controls.Add(selectionPanel);

            //Summary Panel
            Panel summaryPanel = new Panel();
            summaryPanel.Size = new Size(450, mainPanel.Height);
            summaryPanel.BackColor = Color.FromArgb(0, 232, 0);
            summaryPanel.Location = new Point(mainPanel.Width - summaryPanel.Width, 0);
            mainPanel.Controls.Add(summaryPanel);
        }
    }
}

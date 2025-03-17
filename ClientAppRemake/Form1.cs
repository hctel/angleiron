namespace ClientAppRemake
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(1280, 720);
            this.MinimumSize = new Size(1280, 720);
            this.MaximumSize = new Size(1280, 720);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "AngleIron V2";
            this.MaximizeBox = false;
        }
    }
}

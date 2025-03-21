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
            selectionPanel.Dock = DockStyle.Left;
            mainPanel.Controls.Add(selectionPanel);

            //Summary Panel
            Panel summaryPanel = new Panel();
            summaryPanel.Size = new Size(450, mainPanel.Height);
            summaryPanel.BackColor = Color.FromArgb(0, 232, 0);
            summaryPanel.Location = new Point(mainPanel.Width - summaryPanel.Width - 25, 0);
            mainPanel.Controls.Add(summaryPanel);

            //Preview Panel
            Panel previewPanel = new Panel();
            previewPanel.BackColor = Color.FromArgb(255, 255, 255);
            previewPanel.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(previewPanel);

            //Color button
            Button choiceOneButton = new Button();
            choiceOneButton.Size = new Size(50, 50);
            choiceOneButton.Location = new Point(0, 0);
            choiceOneButton.FlatStyle = FlatStyle.Flat;
            choiceOneButton.FlatAppearance.BorderSize = 0;
            choiceOneButton.BackColor = Color.FromArgb(187, 153, 112);
            Button choiceTwoButton = new Button();
            choiceTwoButton.Size = new Size(50, 50);
            choiceTwoButton.Location = new Point(50, 0);
            choiceTwoButton.FlatStyle = FlatStyle.Flat;
            choiceTwoButton.FlatAppearance.BorderSize = 0;
            choiceTwoButton.BackColor = Color.FromArgb(88, 76, 69);
            Button choiceThreeButton = new Button();
            choiceThreeButton.Size = new Size(50, 50);
            choiceThreeButton.Location = new Point(100, 0);
            choiceThreeButton.FlatStyle = FlatStyle.Flat;
            choiceThreeButton.FlatAppearance.BorderSize = 0;
            choiceThreeButton.BackColor = Color.FromArgb(191, 180, 157);
            Button choiceFourButton = new Button();
            choiceFourButton.Size = new Size(50, 50);
            choiceFourButton.Location = new Point(150, 0);
            choiceFourButton.FlatStyle = FlatStyle.Flat;
            choiceFourButton.FlatAppearance.BorderSize = 0;
            choiceFourButton.BackColor = Color.FromArgb(166, 167, 171);

            //Color Group
            GroupBox colorGroup = new GroupBox();
            colorGroup.BackColor = Color.FromArgb(200, 200, 200);
            colorGroup.FlatStyle = FlatStyle.Flat;
            colorGroup.Size = new Size(360,75);
            colorGroup.Controls.Add(choiceOneButton);
            colorGroup.Controls.Add(choiceTwoButton);
            colorGroup.Controls.Add(choiceThreeButton);
            colorGroup.Controls.Add(choiceFourButton);
            colorGroup.Location = new Point((selectionPanel.Width - colorGroup.Width) / 2, selectionPanel.Height - 200);
            selectionPanel.Controls.Add(colorGroup);
        }
    }
}

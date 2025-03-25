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
using System.Net;
using System.Net.Sockets;
using clientapp;


namespace ClientAppRemake
{
    public partial class Form1 : Form
    {
        private bool adding = false;
        private List<int> Articles = new List<int>();
        private List<int> Basket = new List<int>();
        private Color colorPanel = Color.FromArgb(0, 0, 0);
        private Color baseColor = Color.FromArgb(0, 0, 0);
        private Color firstColor = Color.FromArgb(187, 153, 112);
        private Color secondColor = Color.FromArgb(88, 76, 69);
        private Color thirdColor = Color.FromArgb(191, 180, 157);
        private Color fourthColor = Color.FromArgb(166, 167, 171);
        private Bitmap image; // Variable de classe pour le Bitmap
        private string currentImagePath; // Variable de classe pour le chemin de l'image actuelle

        private Network network;

        public Form1()
        {


        InitializeComponent();
            this.Size = new Size(1600, 900);
            this.MinimumSize = new Size(1600, 900);
            this.MaximumSize = new Size(1600, 900);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "AngleIron V2";
            this.MaximizeBox = false;
            this.AutoScaleMode = AutoScaleMode.None;

            this.Load += new EventHandler(Form1_Load);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Header Panel
            Panel headerPanel = new Panel();
            headerPanel.Size = new Size(1600, 100);
            headerPanel.BackColor = Color.FromArgb(0, 168, 232);
            headerPanel.Location = new Point(0, 0);
            this.Controls.Add(headerPanel);

            headerPanel.Controls.Add(new Label
            {
                Text = "AngleIron V2",
                Font = new Font("Comic sans MS", 18, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(10, 20),
                AutoSize = true
            });

            //Footer Panel
            Panel footerPanel = new Panel();
            footerPanel.Size = new Size(1600, 100);
            footerPanel.BackColor = Color.FromArgb(0, 168, 232);
            footerPanel.Location = new Point(0, this.ClientSize.Height - footerPanel.Height);
            this.Controls.Add(footerPanel);

            //Main Panel
            Panel mainPanel = new Panel();
            mainPanel.Size = new Size(1600, 900 - headerPanel.Height - footerPanel.Height);
            mainPanel.BackColor = Color.FromArgb(255, 255, 255);
            mainPanel.Location = new Point(0, headerPanel.Height);
            this.Controls.Add(mainPanel);

            //Selection Panel
            Panel selectionPanel = new Panel();
            selectionPanel.Size = new Size(350, mainPanel.Height);
            selectionPanel.BackColor = Color.FromArgb(200, 200, 200);
            selectionPanel.Dock = DockStyle.Left;
            mainPanel.Controls.Add(selectionPanel);
            selectionPanel.Controls.Add(new Label
            {
                Text = "Lockers",
                Font = new Font("Comic sans MS", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(125, 10),
                AutoSize = true
            });

            //Summary Panel
            Panel summaryPanel = new Panel();
            summaryPanel.Size = new Size(350, mainPanel.Height);
            summaryPanel.BackColor = Color.FromArgb(0, 232, 0);
            summaryPanel.Location = new Point(mainPanel.Width - summaryPanel.Width - 25, 0);
            mainPanel.Controls.Add(summaryPanel);
            summaryPanel.Controls.Add(new Label
            {
                Text = "Summary",
                Font = new Font("Comic sans MS", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(110, 10),
                AutoSize = true
            });

            //Preview Panel
            Panel previewPanel = new Panel();
            previewPanel.BackColor = Color.FromArgb(255, 0, 255);
            previewPanel.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(previewPanel);
            previewPanel.Controls.Add(new Label
            {
                Text = "Preview",
                Font = new Font("Comic sans MS", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(850, 10),
                AutoSize = true
            });

            //Color button
            Button choiceZeroButton = new Button();
            choiceZeroButton.Size = new Size(50, 50);
            choiceZeroButton.Location = new Point(0, 0);
            choiceZeroButton.FlatStyle = FlatStyle.Flat;
            choiceZeroButton.FlatAppearance.BorderSize = 0;
            choiceZeroButton.BackColor = baseColor;
            Button choiceOneButton = new Button();
            choiceOneButton.Size = new Size(50, 50);
            choiceOneButton.Location = new Point(50, 0);
            choiceOneButton.FlatStyle = FlatStyle.Flat;
            choiceOneButton.FlatAppearance.BorderSize = 0;
            choiceOneButton.BackColor = firstColor;
            Button choiceTwoButton = new Button();
            choiceTwoButton.Size = new Size(50, 50);
            choiceTwoButton.Location = new Point(100, 0);
            choiceTwoButton.FlatStyle = FlatStyle.Flat;
            choiceTwoButton.FlatAppearance.BorderSize = 0;
            choiceTwoButton.BackColor = secondColor;
            Button choiceThreeButton = new Button();
            choiceThreeButton.Size = new Size(50, 50);
            choiceThreeButton.Location = new Point(150, 0);
            choiceThreeButton.FlatStyle = FlatStyle.Flat;
            choiceThreeButton.FlatAppearance.BorderSize = 0;
            choiceThreeButton.BackColor = thirdColor;
            Button choiceFourButton = new Button();
            choiceFourButton.Size = new Size(50, 50);
            choiceFourButton.Location = new Point(200, 0);
            choiceFourButton.FlatStyle = FlatStyle.Flat;
            choiceFourButton.FlatAppearance.BorderSize = 0;
            choiceFourButton.BackColor = fourthColor;

            //Color Group
            GroupBox colorGroup = new GroupBox();
            colorGroup.BackColor = Color.FromArgb(200, 200, 200);
            colorGroup.FlatStyle = FlatStyle.Flat;
            colorGroup.Size = new Size(250,50);
            colorGroup.Controls.Add(choiceZeroButton);
            colorGroup.Controls.Add(choiceOneButton);
            colorGroup.Controls.Add(choiceTwoButton);
            colorGroup.Controls.Add(choiceThreeButton);
            colorGroup.Controls.Add(choiceFourButton);
            colorGroup.Location = new Point((selectionPanel.Width - colorGroup.Width) / 2, selectionPanel.Height - 180);
            selectionPanel.Controls.Add(colorGroup);

            //Lockers list panel
            Panel lockersListPanel = new Panel();
            lockersListPanel.Size = new Size(selectionPanel.Width, 450);
            lockersListPanel.Location = new Point(0, 90);
            lockersListPanel.BackColor = Color.FromArgb(250, 250, 250);
            selectionPanel.Controls.Add(lockersListPanel);
            lockersListPanel.AutoScroll = true;

            //Command buttons
            Button addButton = new Button();
            addButton.Size = new Size(120, 80);
            addButton.Location = new Point(780, previewPanel.Height - 180);
            addButton.FlatStyle = FlatStyle.Flat;
            addButton.FlatAppearance.BorderSize = 0;
            addButton.BackColor = Color.FromArgb(94, 176, 87);
            addButton.ForeColor = Color.White;
            addButton.Text = "Add";
            addButton.Font = new Font("Comic sans MS", 14, FontStyle.Bold);
            previewPanel.Controls.Add(addButton);

            Button previewButton = new Button();
            previewButton.Size = new Size(180, 80);
            previewButton.Location = new Point(942, previewPanel.Height - 180);
            previewButton.FlatStyle = FlatStyle.Flat;
            previewButton.FlatAppearance.BorderSize = 0;
            previewButton.BackColor = Color.FromArgb(168, 168, 168);
            previewButton.ForeColor = Color.White;
            previewButton.Text = "Preview";
            previewButton.Font = new Font("Comic sans MS", 14, FontStyle.Bold);
            previewPanel.Controls.Add(previewButton);

            Button orderButton = new Button();
            orderButton.Size = new Size(150, 80);
            orderButton.Location = new Point(footerPanel.Width - 250, 40);
            orderButton.FlatStyle = FlatStyle.Flat;
            orderButton.FlatAppearance.BorderSize = 0;
            orderButton.BackColor = Color.FromArgb(243, 187, 78);
            orderButton.ForeColor = Color.White;
            orderButton.Text = "Order";
            orderButton.Font = new Font("Comic sans MS", 14, FontStyle.Bold);
            footerPanel.Controls.Add(orderButton);

            //For each item
            //Item panel starts here
            Panel itemPanel = new Panel();
            itemPanel.Size = new Size(375, 400);
            itemPanel.Location = new Point(25, 25);
            itemPanel.BackColor = Color.FromArgb(200, 200, 200);
            lockersListPanel.Controls.Add(itemPanel);
            itemPanel.Controls.Add(new Label
            {
                Text = "690 x 690 x 690",
                Font = new Font("Comic sans MS", 12, FontStyle.Bold),
                ForeColor = Color.Black,
                BackColor = Color.FromArgb(255, 255, 255),
                Location = new Point(0, 20),
                AutoSize = true
            });
            itemPanel.Controls.Add(new Label
            {
                Text = "14.99€",
                Font = new Font("Comic sans MS", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(30, itemPanel.Height - 85),
                AutoSize = true
            });
            Button selectButton = new Button();
            selectButton.Size = new Size(160, 70);
            selectButton.Location = new Point(200, itemPanel.Height - 90);
            selectButton.FlatStyle = FlatStyle.Flat;
            selectButton.FlatAppearance.BorderSize = 0;
            selectButton.BackColor = Color.FromArgb(243, 187, 78);
            selectButton.ForeColor = Color.White;
            selectButton.Text = "Select";
            selectButton.Font = new Font("Comic sans MS", 14, FontStyle.Bold);
            itemPanel.Controls.Add(selectButton);
            PictureBox itemImage = new PictureBox();
            itemImage.Size = new Size(375, 300);
            itemImage.Location = new Point(35, 150);
            itemImage.Image = Image.FromFile("Images/image2.png");
            itemPanel.Controls.Add(itemImage);
            //Item panel ends here

            //Preview image
            PictureBox previewImage = new PictureBox();
            previewImage.Size = new Size(600, 600);
            previewImage.Location = new Point(800, 300);
            previewImage.Image = Image.FromFile("Images/image1.png");
            previewPanel.Controls.Add(previewImage);

            //Summary list panel
            Panel itemSummaryPanel = new Panel();
            itemSummaryPanel.Size = new Size(400, 70);
            itemSummaryPanel.Location = new Point(25, 100);
            itemSummaryPanel.BackColor = Color.FromArgb(200, 200, 200);
            summaryPanel.Controls.Add(itemSummaryPanel);
            Button removeButton = new Button();
            removeButton.Size = new Size(70, 70);
            removeButton.Location = new Point(0, 0);
            removeButton.FlatStyle = FlatStyle.Flat;
            removeButton.FlatAppearance.BorderSize = 0;
            removeButton.BackColor = Color.FromArgb(255, 0, 0);
            removeButton.ForeColor = Color.White;
            removeButton.Text = "X";
            removeButton.Font = new Font("Comic sans MS", 14, FontStyle.Bold);
            itemSummaryPanel.Controls.Add(removeButton);
            itemSummaryPanel.Controls.Add(new Label
            {
                Text = "690 x 690 x 690",
                Font = new Font("Comic sans MS", 12, FontStyle.Bold),
                ForeColor = Color.Black,
                BackColor = Color.FromArgb(255, 255, 255),
                Location = new Point(80, 12),
                AutoSize = true
            });


        }
    }
}

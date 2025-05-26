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
        private bool selecting = false;
        private List<int> Articles = new List<int>();
        private List<Tuple<int, Color>> Basket = new List<Tuple<int, Color>>();
        private int selectedId;
        private Color colorPanel = Color.FromArgb(0, 0, 0);
        private Color baseColor = Color.FromArgb(0, 0, 0);
        private Color firstColor = Color.FromArgb(187, 153, 112);
        private Color secondColor = Color.FromArgb(88, 76, 69);
        private Color thirdColor = Color.FromArgb(191, 180, 157);
        private Color fourthColor = Color.FromArgb(166, 167, 171);
        private Color selectedColor = Color.FromArgb(255, 255, 255);
        private Bitmap image; // Variable de classe pour le Bitmap
        private string currentImagePath; // Variable de classe pour le chemin de l'image actuelle
        private Panel previewPanel = new Panel();
        private PictureBox previewImage = new PictureBox();
        private Panel summaryPanel = new Panel();
        private Network network;
        private double finalPrice = 0;
        private Label finalPriceLabel = new Label();


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
            this.AutoScaleMode = AutoScaleMode.None;

            this.Load += new EventHandler(Form1_Load);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            network = new Network("hctel.net",58913);
            
            //Header Panel
            Panel headerPanel = new Panel();
            headerPanel.Size = new Size(1920, 120);
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
            Button loginButton = new Button();
            loginButton.Size = new Size(120, 60);
            loginButton.Location = new Point(headerPanel.Width - 250, 30);
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.BackColor = Color.FromArgb(0, 168, 232);
            loginButton.ForeColor = Color.White;
            loginButton.FlatAppearance.BorderSize = 2;
            loginButton.FlatAppearance.BorderColor = Color.White;
            loginButton.Text = "Login";
            loginButton.Font = new Font("Comic sans MS", 12, FontStyle.Bold);
            loginButton.TextAlign = ContentAlignment.MiddleCenter;
            loginButton.Click += (s, ev) =>
            {
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
                if (loginForm.DialogResult == DialogResult.OK)
                {
                    string username = loginForm.Username;
                    string password = loginForm.Password;
                    // Handle login logic here
                }
            };
            headerPanel.Controls.Add(loginButton);


            //Footer Panel
            Panel footerPanel = new Panel();
            footerPanel.Size = new Size(1920, 150);
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
            summaryPanel.Size = new Size(450, mainPanel.Height);
            summaryPanel.BackColor = Color.FromArgb(200, 200, 200);
            summaryPanel.Dock = DockStyle.Right;
            mainPanel.Controls.Add(summaryPanel);
            summaryPanel.Controls.Add(new Label
            {
                Text = "Summary",
                Font = new Font("Comic sans MS", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(110, 10),
                AutoSize = true
            });

            finalPriceLabel.Text = "Total : 0 €";
            finalPriceLabel.Font = new Font("Comic sans MS", 12, FontStyle.Bold);
            finalPriceLabel.ForeColor = Color.Black;
            finalPriceLabel.Location = new Point(25, summaryPanel.Height - 130);
            finalPriceLabel.AutoSize = true;

            summaryPanel.Controls.Add(finalPriceLabel);


            //Preview Panel

            previewPanel.Size = new Size(mainPanel.Width - selectionPanel.Width - summaryPanel.Width, mainPanel.Height);
            previewPanel.BackColor = Color.FromArgb(220, 240, 250);
            previewPanel.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(previewPanel);
            previewPanel.Controls.Add(new Label
            {
                Text = "Preview",
                Font = new Font("Comic sans MS", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(900, 10),
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

            choiceZeroButton.Click += (s, ev) => changeColor(baseColor);
            choiceOneButton.Click += (s, ev) => changeColor(firstColor);
            choiceTwoButton.Click += (s, ev) => changeColor(secondColor);
            choiceThreeButton.Click += (s, ev) => changeColor(thirdColor);
            choiceFourButton.Click += (s, ev) => changeColor(fourthColor);

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
            colorGroup.Location = new Point((selectionPanel.Width - colorGroup.Width) / 2, selectionPanel.Height - 150);
            selectionPanel.Controls.Add(colorGroup);

            //Lockers list panel
            Panel lockersListPanel = new Panel();
            lockersListPanel.Size = new Size(selectionPanel.Width, 550);
            lockersListPanel.Location = new Point(0, 70);
            lockersListPanel.BackColor = Color.FromArgb(250, 250, 250);
            selectionPanel.Controls.Add(lockersListPanel);
            lockersListPanel.AutoScroll = true;

            //Command buttons
            Button addButton = new Button();
            addButton.Size = new Size(120, 80);
            addButton.Location = new Point(780, previewPanel.Height - 170);
            addButton.FlatStyle = FlatStyle.Flat;
            addButton.FlatAppearance.BorderSize = 0;
            addButton.BackColor = Color.FromArgb(94, 176, 87);
            addButton.ForeColor = Color.White;
            addButton.Text = "Add";
            addButton.Font = new Font("Comic sans MS", 14, FontStyle.Bold);
            previewPanel.Controls.Add(addButton);
            addButton.Click += (s, ev) => Add(selectedId, selectedColor);

            Button previewButton = new Button();
            previewButton.Size = new Size(180, 80);
            previewButton.Location = new Point(942, previewPanel.Height - 170);
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
            orderButton.Click += (s, ev) => Order();

            //For each item
            //Item panel starts here
            int index=-1;
            foreach (Kit k in network.getItems())
            {
                int id = k.id;
                if(index == -1) index = id;
                int posX = index-1;
                Panel itemPanel = new Panel();
                itemPanel.Size = new Size(390, 490);
                itemPanel.Location = new Point(15, 25 + posX * 515);
                itemPanel.BackColor = Color.FromArgb(200, 200, 200);
                lockersListPanel.Controls.Add(itemPanel);

                itemPanel.Controls.Add(new Label
                {
                    Text = k.dimension,
                    Font = new Font("Comic sans MS", 12, FontStyle.Bold),
                    ForeColor = Color.Black,
                    BackColor = Color.FromArgb(255, 255, 255),
                    Location = new Point(0, 20),
                    AutoSize = true
                });

                itemPanel.Controls.Add(new Label
                {
                    Text = k.price.ToString() + " €",
                    Font = new Font("Comic sans MS", 12, FontStyle.Bold),
                    ForeColor = Color.Black,
                    Location = new Point(30, itemPanel.Height - 60),
                    AutoSize = true
                });

                Button selectButton = new Button();
                selectButton.Size = new Size(140, 60);
                selectButton.Location = new Point(210, itemPanel.Height - 70);
                selectButton.FlatStyle = FlatStyle.Flat;
                selectButton.FlatAppearance.BorderSize = 0;
                selectButton.BackColor = Color.FromArgb(243, 187, 78);
                selectButton.ForeColor = Color.White;
                selectButton.Text = "Select";
                selectButton.Font = new Font("Comic sans MS", 12, FontStyle.Bold);
                itemPanel.Controls.Add(selectButton);
                selectButton.Click += (s, ev) => SelectImage(id);
                
                PictureBox itemImage = new PictureBox();

                itemImage.SizeMode = PictureBoxSizeMode.StretchImage;
                itemImage.Size = new Size(300, 50);
                itemImage.Location = new Point(45, 200);

                itemImage.Image = Image.FromFile("Images/" + k.image);
                itemPanel.Controls.Add(itemImage);

                Panel spacerPanel = new Panel();
                spacerPanel.Size = new Size(390, 20);
                spacerPanel.Location = new Point(15, lockersListPanel.Controls[lockersListPanel.Controls.Count - 1].Bottom + 10);
                spacerPanel.BackColor = Color.Transparent;
                lockersListPanel.Controls.Add(spacerPanel);

                index++;
                
            }
            //Item panel ends here
            
            //Preview image
            
            this.previewImage.Size = new Size(600, 600);
            this.previewImage.Location = new Point(800, 300);
            
            if (!selecting)
            {
                string path = "Images/image.png";
                this.previewImage.Image = Image.FromFile(path);
                this.image = new Bitmap(path);
            }
            this.previewPanel.Controls.Add(previewImage);
           
        }

        private void SelectImage(int articleIndex)
        {
            this.selectedColor = Color.FromArgb(255, 255, 255);
            this.selectedId = articleIndex;
            selecting = true;
            string path = "Images/image" + articleIndex + ".png";
            this.previewImage.Image = Image.FromFile(path);
            this.image = new Bitmap(path);
        }

        private void changeColor(Color newcolor)
        {
            colorPanel = newcolor;
            this.previewImage.Image = setColor(image, colorPanel);
            this.selectedColor = newcolor;
            this.Refresh();
        }

        private static Bitmap setColor(Bitmap originalImage, Color newColor)
        {
            Bitmap result = new Bitmap(originalImage.Width, originalImage.Height);

            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color pixel = originalImage.GetPixel(x, y);
                    if (pixel.A == 0)
                    {
                        result.SetPixel(x, y, Color.Transparent);
                    }
                    else
                    {
                        result.SetPixel(x, y, Color.FromArgb(pixel.A, newColor));
                    }
                }
            }
            return result;
        }
        private void Remove(int selectedId, Color selectedColor, Panel sum)
        {
            Kit kit = network.getItems().FirstOrDefault(k => k.id == selectedId);
            var item = new Tuple<int, Color>(selectedId, selectedColor);
            if (!Basket.Contains(item))
            {
                MessageBox.Show("Item not found in basket.");
                return;
            }
            else
            {
                Basket.Remove(item);
                summaryPanel.Controls.Remove(sum);
                this.finalPrice -= kit.price;
                finalPriceLabel.Text = "Total : " + finalPrice.ToString("0.00") + " €";
                ReorderSummaryItems();
            }
            // Missing update preview image
        }
        private void ReorderSummaryItems()
        {
            int y = 100;
            foreach (Control ctrl in summaryPanel.Controls)
            {
                if (ctrl is Panel itemPanel)
                {
                    itemPanel.Location = new Point(25, y);
                    y += 70;
                }
            }
        }

        private void Add(int selectedId, Color selectedColor)
        {
            var item = new Tuple<int, Color>(selectedId, selectedColor);
            Basket.Add(item);

            Kit kit = network.getItems().FirstOrDefault(k => k.id == selectedId);
            if (kit == null)
            {
                MessageBox.Show("Kit not found.");
                return;
            }

            if(Basket.Count > 7)
            {
                MessageBox.Show("Maximum 7 lockers allowed.");
                return;
            }


            Panel itemSummaryPanel = new Panel();
            itemSummaryPanel.Size = new Size(370, 60);
            itemSummaryPanel.Location = new Point(25, 100 + 70 * (Basket.Count - 1));
            itemSummaryPanel.BackColor = Color.FromArgb(200, 200, 200);
            this.summaryPanel.Controls.Add(itemSummaryPanel);

            Panel colorPanel = new Panel();
            colorPanel.Size = new Size(60, 60);
            colorPanel.Location = new Point(70, 0);
            colorPanel.BackColor = selectedColor;
            itemSummaryPanel.Controls.Add(colorPanel);
            colorPanel.BringToFront();

            Button removeButton = new Button();
            removeButton.Size = new Size(60, 60);
            removeButton.Location = new Point(0, 0);
            removeButton.FlatStyle = FlatStyle.Flat;
            removeButton.FlatAppearance.BorderSize = 0;
            removeButton.BackColor = Color.FromArgb(255, 0, 0);
            removeButton.ForeColor = Color.White;
            removeButton.Text = "X";
            removeButton.TextAlign = ContentAlignment.MiddleCenter;
            removeButton.Font = new Font("Comic sans MS", 14, FontStyle.Bold);
            itemSummaryPanel.Controls.Add(removeButton);
            removeButton.Click += (s, ev) => Remove(selectedId, selectedColor, itemSummaryPanel);

            itemSummaryPanel.Controls.Add(new Label
            {
                Text = kit.dimension,
                Font = new Font("Comic sans MS", 12, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(140, 10),
                AutoSize = true
            });
            this.finalPrice += kit.price;
            finalPriceLabel.Text = "Total : " + finalPrice.ToString("0.00") + " €";
        }
        private void Order()
        {
            if (Basket.Count == 0)
            {
                MessageBox.Show("No items in basket.");
                return;
            }

            string orderSummary = "Order Summary:\n";
            foreach (var item in Basket)
            {
                Kit kit = network.getItems().FirstOrDefault(k => k.id == item.Item1);
                orderSummary += $"{kit.dimension} - {item.Item2}\n";
            }
            orderSummary += $"Total: {finalPrice.ToString("0.00")} €";

            MessageBox.Show(orderSummary, "Order Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

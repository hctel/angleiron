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

namespace clientapp
{
    public partial class Window : Form
    {
        private bool adding = false;
        private List<int> Articles = new List<int>();
        private List<int> Basket = new List<int>();
        private Color colorPanel = Color.Empty;
        private Color firstColor = Color.FromArgb(187, 153, 112);
        private Color secondColor = Color.FromArgb(88, 76, 69);
        private Color thirdColor = Color.FromArgb(191, 180, 157);
        private Color fourthColor = Color.FromArgb(166, 167, 171);

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
            Articles.Add(1);
            Articles.Add(2);
            Articles.Add(3);

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


            this.LockersLabel.BackColor = Color.FromArgb(200, 200, 200);
            this.LockersLabel.Location = new Point(90, 90);

            this.ColorLabel.BackColor = Color.FromArgb(200, 200, 200);
            this.ColorLabel.Location = new Point(115, this.Height - 255);

            this.SummaryLabel.BackColor = Color.FromArgb(200, 200, 200);
            this.SummaryLabel.Location = new Point(this.Width - 230, 90);

            //To be optimized
            Button choiceOneButton = new Button();
            choiceOneButton.Size = new Size(50, 50);
            choiceOneButton.Location = new Point(0, 0);
            choiceOneButton.FlatStyle = FlatStyle.Flat;
            choiceOneButton.FlatAppearance.BorderSize = 0;
            Button choiceTwoButton = new Button();
            choiceTwoButton.Size = new Size(50, 50);
            choiceTwoButton.Location = new Point(50, 0);
            choiceTwoButton.FlatStyle = FlatStyle.Flat;
            choiceTwoButton.FlatAppearance.BorderSize = 0;
            Button choiceThreeButton = new Button();
            choiceThreeButton.Size = new Size(50, 50);
            choiceThreeButton.Location = new Point(100, 0);
            choiceThreeButton.FlatStyle = FlatStyle.Flat;
            choiceThreeButton.FlatAppearance.BorderSize = 0;
            Button choiceFourButton = new Button();
            choiceFourButton.Size = new Size(50, 50);
            choiceFourButton.Location = new Point(150, 0);
            choiceFourButton.FlatStyle = FlatStyle.Flat;
            choiceFourButton.FlatAppearance.BorderSize = 0;

            ColorGroup.Controls.Add(choiceOneButton);
            ColorGroup.Controls.Add(choiceTwoButton);
            ColorGroup.Controls.Add(choiceThreeButton);
            ColorGroup.Controls.Add(choiceFourButton);
            ColorGroup.Size = new Size(200, 50);

            ColorGroup.Location = new Point(50, this.Height - 225);
            ColorGroup.BackColor = Color.FromArgb(200, 200, 200);
            ColorGroup.FlatStyle = FlatStyle.Flat;

            choiceOneButton.BackColor = firstColor;
            choiceTwoButton.BackColor = secondColor;
            choiceThreeButton.BackColor = thirdColor;
            choiceFourButton.BackColor = fourthColor;

            choiceOneButton.Click += (s, ev) => changeColor(firstColor);
            choiceTwoButton.Click += (s, ev) => changeColor(secondColor);
            choiceThreeButton.Click += (s, ev) => changeColor(thirdColor);
            choiceFourButton.Click += (s, ev) => changeColor(fourthColor);



            foreach (int i in Articles)
            {
                int a = i - 1;
                Debug.WriteLine(i);

                Panel contentPanel = new Panel();
                contentPanel.Size = new Size(260, 300);
                contentPanel.Location = new Point(12, 10 + a * 310);
                contentPanel.Size = new Size(250, 300);
                contentPanel.Location = new Point(30, 10 + a * 310);
                contentPanel.BackColor = Color.FromArgb(0, 200, 0);

                Button addButton = new Button();
                addButton.Size = new Size(80, 30);
                addButton.Text = "Select";
                addButton.TextAlign = ContentAlignment.MiddleCenter;
                addButton.Location = new Point(contentPanel.Width - 95, contentPanel.Height - 45);
                addButton.FlatStyle = FlatStyle.Flat;
                addButton.FlatAppearance.BorderSize = 0;
                addButton.BackColor = Color.FromArgb(0, 0, 0);
                addButton.ForeColor = Color.White;
                contentPanel.Controls.Add(addButton);
                addButton.Click += addButton_Click;

                
                Label infoLabel = new Label();
                infoLabel.Size = new Size(200, 30);
                infoLabel.Text = "69 x 69 cm " + i;
                contentPanel.Controls.Add(infoLabel);
                infoLabel.Location = new Point(15, contentPanel.Height - 45);
                infoLabel.Font = new Font("Sans Serif", 16);

                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = Image.FromFile("./Images/image1.png"); // Charge l'image
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Ajuste l'image à la taille du PictureBox
                pictureBox.Size = new Size(300, 50); // Définir la taille
                pictureBox.Location = new Point(490, 335); // Définir la position

                ContainerPanel.Controls.Add(contentPanel);

                if(adding)
                {
                    Add(i);
                }
            }

        }

        private void changeColor(Color newcolor)
        {
            colorPanel = newcolor;
            this.Refresh();

        }
        private void addButton_Click(object sender, EventArgs e)
        {
            adding = true;            
            Debug.WriteLine("Button clicked");
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
            this.lockersPanel.BackColor = Color.FromArgb(200, 200, 200);
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
            this.SummaryPanel.BackColor = Color.FromArgb(200, 200, 200);
            this.SummaryPanel.Location = new Point(this.Width-300, 70);
        }
        private void LockersLabel_Click(object sender, EventArgs e)
        {
        }

        private void SummaryLabel_Click(object sender, EventArgs e)
        {

        }

        private void ColorGroup_Enter(object sender, EventArgs e)
        {

        }

        private void ColorLabel_Click(object sender, EventArgs e)
        {

        }

        private void ContainerPanel_Paint(object sender, PaintEventArgs e)
        {
            this.ContainerPanel.Size = new Size(300, 320);
            this.ContainerPanel.Location = new Point(0, 130);
            this.ContainerPanel.BackColor = Color.FromArgb(220, 220, 220);
            this.ContainerPanel.AutoScroll = true; 
        }
        private void Remove(int obj)
        {
            Basket.Remove(obj);
        }
        private void Add(int obj)
        {
            Basket.Add(Articles[obj]);

        }

        private void ImagePanel_Paint(object sender, PaintEventArgs e)
        {
            
            this.ImagePanel.Size = new Size(680, 490);
            this.ImagePanel.Location = new Point(300, 70);
 
            this.ImagePanel.BackColor = Color.FromArgb(255,255,255);

            // Charger l'image en tant que Bitmap
            Bitmap image = new Bitmap("./Images/image1.png");

            // Changer la couleur de l'image
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    if (pixelColor.A > 0) // Si le pixel n'est pas transparent
                    {
                        image.SetPixel(x, y, colorPanel);
                    }
                }
            }

            // Dessiner l'image sur le panneau
            e.Graphics.DrawImage(image, new Point(200, 200));
        }
    }
}

using System;
using System.Windows.Forms;

namespace ClientAppRemake
{
    public partial class LoginForm : Form
    {
        public string Username => usernameTextBox.Text;
        public string Password => passwordTextBox.Text;

        private TextBox usernameTextBox;
        private TextBox passwordTextBox;

        public LoginForm()
        {
            this.Text = "Login";
            this.Size = new System.Drawing.Size(600, 350);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            int labelX = 50;
            int inputX = 180;
            int labelWidth = 120;
            int textboxWidth = 300;

            int row1Y = 60;
            int row2Y = 120;

            Label userLabel = new Label()
            {
                Text = "Username:",
                Location = new System.Drawing.Point(labelX, row1Y),
                Size = new System.Drawing.Size(labelWidth + 8, 30),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };

            usernameTextBox = new TextBox()
            {
                Location = new System.Drawing.Point(inputX, row1Y),
                Width = textboxWidth,
                Height = 30
            };

            Label passLabel = new Label()
            {
                Text = "Password:",
                Location = new System.Drawing.Point(labelX, row2Y),
                Size = new System.Drawing.Size(labelWidth + 8, 30),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };

            passwordTextBox = new TextBox()
            {
                Location = new System.Drawing.Point(inputX, row2Y),
                Width = textboxWidth,
                Height = 30,
                PasswordChar = '*'
            };

            Button loginButton = new Button()
            {
                Text = "Login",
                Location = new System.Drawing.Point((this.ClientSize.Width - 100) / 2, 200),
                Size = new System.Drawing.Size(100, 40),
                DialogResult = DialogResult.OK
            };

            this.Controls.Add(userLabel);
            this.Controls.Add(usernameTextBox);
            this.Controls.Add(passLabel);
            this.Controls.Add(passwordTextBox);
            this.Controls.Add(loginButton);

            this.AcceptButton = loginButton;
        }
    }
}

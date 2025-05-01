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
            this.Size = new System.Drawing.Size(500, 300);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            Label userLabel = new Label() { Text = "Username:", Location = new System.Drawing.Point(30, 30), AutoSize = true };
            usernameTextBox = new TextBox() { Location = new System.Drawing.Point(120, 30), Width = 200 };

            Label passLabel = new Label() { Text = "Password:", Location = new System.Drawing.Point(30, 80), AutoSize = true };
            passwordTextBox = new TextBox() { Location = new System.Drawing.Point(120, 80), Width = 200, PasswordChar = '*' };

            Button loginButton = new Button()
            {
                Text = "Login",
                Location = new System.Drawing.Point(150, 140),
                DialogResult = DialogResult.OK
            };

            this.Controls.Add(userLabel);
            this.Controls.Add(usernameTextBox);
            this.Controls.Add(passLabel);
            this.Controls.Add(passwordTextBox);
            this.Controls.Add(loginButton);

            this.AcceptButton = loginButton; // permet d'appuyer sur "Entrée"
        }
    }
}

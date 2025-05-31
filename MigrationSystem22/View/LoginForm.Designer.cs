namespace MigrationSystem22.View
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private TabControl tabControlAuth;
        private TabPage tabPageLogin;
        private TabPage tabPageRegister;

        private TextBox txtLoginUsername;
        private TextBox txtLoginPassword;
        private Button btnLogin;

        private TextBox txtRegUsername;
        private TextBox txtRegPassword;
        private Button btnRegister;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControlAuth = new TabControl();
            this.tabPageLogin = new TabPage();
            this.tabPageRegister = new TabPage();

            // ==== TabControl ====
            this.tabControlAuth.Controls.Add(this.tabPageLogin);
            this.tabControlAuth.Controls.Add(this.tabPageRegister);
            this.tabControlAuth.Dock = DockStyle.Fill;
            this.tabControlAuth.SelectedIndex = 0;

            // ==== tabPageLogin ====
            this.tabPageLogin.Text = "Вход";
            this.txtLoginUsername = new TextBox { PlaceholderText = "Логин", Top = 20, Left = 20, Width = 240 };
            this.txtLoginPassword = new TextBox { PlaceholderText = "Пароль", Top = 60, Left = 20, Width = 240, UseSystemPasswordChar = true };
            this.btnLogin = new Button { Text = "Войти", Top = 100, Left = 20, Width = 240, Height = 36 };
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);

            this.tabPageLogin.Controls.Add(this.txtLoginUsername);
            this.tabPageLogin.Controls.Add(this.txtLoginPassword);
            this.tabPageLogin.Controls.Add(this.btnLogin);

            // ==== tabPageRegister ====
            this.tabPageRegister.Text = "Регистрация";
            this.txtRegUsername = new TextBox { PlaceholderText = "Логин", Top = 20, Left = 20, Width = 240 };
            this.txtRegPassword = new TextBox { PlaceholderText = "Пароль", Top = 60, Left = 20, Width = 240, UseSystemPasswordChar = true };
            this.btnRegister = new Button { Text = "Создать аккаунт", Top = 100, Left = 20, Width = 240, Height = 36 };
            this.btnRegister.Click += new EventHandler(this.btnRegister_Click);

            this.tabPageRegister.Controls.Add(this.txtRegUsername);
            this.tabPageRegister.Controls.Add(this.txtRegPassword);
            this.tabPageRegister.Controls.Add(this.btnRegister);

            // ==== LoginForm ====
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Авторизация";

            this.Controls.Add(this.tabControlAuth);
        }
    }
}

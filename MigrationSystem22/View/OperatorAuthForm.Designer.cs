// OperatorAuthForm.Designer.cs
namespace MigrationSystem22.View
{
    partial class OperatorAuthForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLoginOperator;
        private Button btnRegisterOperator;
        private Label lblUser;
        private Label lblPass;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtUsername = new TextBox { Top = 30, Left = 20, Width = 200, PlaceholderText = "Логин" };
            this.txtPassword = new TextBox { Top = 70, Left = 20, Width = 200, UseSystemPasswordChar = true, PlaceholderText = "Пароль" };
            this.btnLoginOperator = new Button { Top = 110, Left = 20, Width = 200, Text = "Войти" };
            this.btnRegisterOperator = new Button { Top = 150, Left = 20, Width = 200, Text = "Создать оператора" };
            this.lblUser = new Label { Top = 10, Left = 20, Text = "Логин:" };
            this.lblPass = new Label { Top = 50, Left = 20, Text = "Пароль:" };

            this.btnLoginOperator.Click += new EventHandler(this.btnLoginOperator_Click);
            this.btnRegisterOperator.Click += new EventHandler(this.btnRegisterOperator_Click);

            this.ClientSize = new System.Drawing.Size(250, 200);
            this.Controls.AddRange(new Control[]
            {
                lblUser, txtUsername,
                lblPass, txtPassword,
                btnLoginOperator, btnRegisterOperator
            });
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Авторизация оператора";
        }
    }
}

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
            this.txtUsername = new TextBox { Top = 35, Left = 30, Width = 240, Height = 36, PlaceholderText = "Логин" };
            this.txtPassword = new TextBox { Top = 70, Left = 30, Width = 240, Height = 36, UseSystemPasswordChar = true, PlaceholderText = "Пароль" };
            this.btnLoginOperator = new Button { Top = 110, Left = 30, Width = 240, Height = 36, Text = "Войти" };
            this.btnRegisterOperator = new Button { Top = 160, Left = 30, Width = 240, Height = 36, Text = "Создать оператора" };

            this.btnLoginOperator.Click += new EventHandler(this.btnLoginOperator_Click);
            this.btnRegisterOperator.Click += new EventHandler(this.btnRegisterOperator_Click);

            this.ClientSize = new System.Drawing.Size(300, 200);
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

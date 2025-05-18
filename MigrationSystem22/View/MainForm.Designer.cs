namespace MigrationSystem22.View
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button buttonOperator;
        private Button buttonUser;

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            buttonOperator = new Button();
            buttonUser = new Button();

            // buttonOperator
            buttonOperator.Text = "Войти как оператор";
            buttonOperator.Size = new System.Drawing.Size(200, 40);
            buttonOperator.Location = new System.Drawing.Point(30, 30);
            buttonOperator.Click += buttonOperator_Click;

            // buttonUser
            buttonUser.Text = "Войти как пользователь";
            buttonUser.Size = new System.Drawing.Size(200, 40);
            buttonUser.Location = new System.Drawing.Point(30, 90);
            buttonUser.Click += buttonUser_Click;

            // MainForm
            Text = "Главное меню";
            ClientSize = new System.Drawing.Size(260, 160);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;
            Controls.Add(buttonOperator);
            Controls.Add(buttonUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }
    }
}

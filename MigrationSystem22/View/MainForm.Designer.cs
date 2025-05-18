namespace MigrationSystem22.View
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button buttonOperator;
        private Button buttonUser;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            buttonOperator = new Button();
            buttonUser = new Button();
            SuspendLayout();
            // 
            // buttonOperator
            // 
            buttonOperator.Location = new Point(50, 40);
            buttonOperator.Name = "buttonOperator";
            buttonOperator.Size = new Size(176, 40);
            buttonOperator.TabIndex = 0;
            buttonOperator.Text = "Войти как оператор";
            buttonOperator.UseVisualStyleBackColor = true;
            buttonOperator.Click += buttonOperator_Click;
            // 
            // buttonUser
            // 
            buttonUser.Location = new Point(50, 100);
            buttonUser.Name = "buttonUser";
            buttonUser.Size = new Size(176, 40);
            buttonUser.TabIndex = 1;
            buttonUser.Text = "Войти как мигрант";
            buttonUser.UseVisualStyleBackColor = true;
            buttonUser.Click += buttonUser_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(250, 200);
            Controls.Add(buttonUser);
            Controls.Add(buttonOperator);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Главное меню";
            ResumeLayout(false);
        }
    }
}

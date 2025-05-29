using System;
using System.Windows.Forms;
using MigrationSystem22.Controllers;

namespace MigrationSystem22.View
{
    public partial class LoginForm : Form
    {
        private readonly UserController _ctrl = new UserController();


        public bool IsNewRegistration { get; private set; }

        public int LoggedInUserId => _ctrl.CurrentUserId;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!_ctrl.LoginMigrant(txtLoginUsername.Text.Trim(),
                                     txtLoginPassword.Text,
                                     out var err))
            {
                MessageBox.Show(err, "Ошибка входа",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IsNewRegistration = false;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!_ctrl.RegisterMigrant(txtRegUsername.Text.Trim(),
                                       txtRegPassword.Text,
                                       out var err))
            {
                MessageBox.Show(err, "Ошибка регистрации",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Аккаунт создан", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            IsNewRegistration = true;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

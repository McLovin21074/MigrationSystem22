using System;
using System.Windows.Forms;
using MigrationSystem22.Controllers;

namespace MigrationSystem22.View
{
    public partial class OperatorAuthForm : Form
    {
        private readonly UserController ctrl;

        public OperatorAuthForm(UserController controller)
        {
            InitializeComponent();
            ctrl = controller;

            btnRegisterOperator.Visible = !ctrl.AnyOperatorExists();
            btnLoginOperator.Visible = ctrl.AnyOperatorExists();
        }

        private void btnRegisterOperator_Click(object sender, EventArgs e)
        {
            if (!ctrl.RegisterOperator(txtUsername.Text.Trim(),
                                        txtPassword.Text,
                                        out var error))
            {
                MessageBox.Show(error, "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Оператор создан", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnLoginOperator_Click(object sender, EventArgs e)
        {
            if (!ctrl.LoginOperator(txtUsername.Text.Trim(),
                                     txtPassword.Text,
                                     out var error))
            {
                MessageBox.Show(error, "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

using MigrationSystem22.Controllers;

namespace MigrationSystem22.View
{
    public partial class LoginForm : Form
    {
        private readonly UserController userController = new UserController();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var name = txtFullName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("ФИО.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var users = userController.GetAllUsers();
            var user = users.FirstOrDefault(u => u.FullName.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (user == null)
            {
                MessageBox.Show("Пользователь не найден:)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using var f = new UserInputForm(user.Id);
            f.ShowDialog();
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            using var f = new UserInputForm(null);
            f.ShowDialog();
            this.Close();
        }
    }
}

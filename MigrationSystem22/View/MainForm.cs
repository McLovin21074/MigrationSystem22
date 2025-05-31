using System;
using System.Windows.Forms;
using MigrationSystem22.Controllers;

namespace MigrationSystem22.View
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonMigrant_Click(object sender, EventArgs e)
        {
            using var auth = new LoginForm();
            if (auth.ShowDialog() != DialogResult.OK)
                return;

            bool forceDetails = auth.IsNewRegistration;
            int userId = auth.LoggedInUserId;

            using var uif = new UserInputForm(userId, forceDetails);
            uif.ShowDialog();
        }

        private void buttonOperator_Click(object sender, EventArgs e)
        {
            var ctrl = new UserController();
            using var f = new OperatorAuthForm(ctrl);
            if (f.ShowDialog() != DialogResult.OK) return;

            using var rules = new RuleListForm();
            rules.ShowDialog();
        }
    }
}

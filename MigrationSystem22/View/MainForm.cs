using System;
using System.Windows.Forms;

namespace MigrationSystem22.View
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonOperator_Click(object sender, EventArgs e)
        {
            using var f = new RuleListForm();
            f.ShowDialog();
        }

        private void buttonUser_Click(object sender, EventArgs e)
        {
            using var f = new UserInputForm();
            f.ShowDialog();
        }
    }
}

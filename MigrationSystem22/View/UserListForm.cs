using System;
using System.Linq;
using System.Windows.Forms;
using MigrationSystem22.Controllers;
using MigrationSystem22.Models;

namespace MigrationSystem22.View
{
    public partial class UserListForm : Form
    {
        private readonly UserController ctrl = new();
        public UserListForm()
        {
            InitializeComponent();
            Load += (_, __) => RefreshGrid();
        }

        private void RefreshGrid()
        {
            var users = ctrl.GetAllUsers()
                            .Select(u => new {
                                u.Id,
                                u.FullName, 
                                EntryDate = u.EntryDate.ToString("dd.MM.yyyy"),
                                u.Country,
                                u.EntryGoal
                            })
                            .ToList();
            dataGridViewUsers.DataSource = users;
            dataGridViewUsers.Columns["Id"].Visible = false;
            dataGridViewUsers.Columns["FullName"].HeaderText = "ФИО";

        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            var form = new UserInputForm(null);
            form.ShowDialog();
            RefreshGrid();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.CurrentRow == null) return;
            int id = (int)dataGridViewUsers.CurrentRow.Cells["Id"].Value;
            var form = new UserInputForm(id);
            form.ShowDialog();
            RefreshGrid();
        }
    }
}

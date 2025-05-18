using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using MigrationSystem22.Controllers;
using MigrationSystem22.Models;

namespace MigrationSystem22.View
{
    public partial class RuleListForm : Form
    {
        private readonly RuleController controller = new RuleController();
        private BindingList<RuleEntity> binding;

        public RuleListForm()
        {
            InitializeComponent();
            LoadRules();
        }

        private void LoadRules()
        {
            var list = controller.GetAllRules();
            binding = new BindingList<RuleEntity>(list);
            dataGridView1.DataSource = binding;

            if (dataGridView1.Columns.Contains("ConditionGroups"))
                dataGridView1.Columns["ConditionGroups"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var f = new RuleInputForm();
            f.ShowDialog();
            LoadRules();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            var rule = (RuleEntity)dataGridView1.CurrentRow.DataBoundItem;
            using var f = new RuleInputForm(rule.RuleId);
            f.ShowDialog();
            LoadRules();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            var rule = (RuleEntity)dataGridView1.CurrentRow.DataBoundItem;
            if (MessageBox.Show($"Удалить правило #{rule.RuleId}?", "Подтвердите",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                controller.DeleteRule(rule.RuleId);
                LoadRules();
            }
        }
    }
}

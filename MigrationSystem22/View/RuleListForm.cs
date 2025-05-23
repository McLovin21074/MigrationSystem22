using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using MigrationSystem22.Controllers;

namespace MigrationSystem22.View
{
    public partial class RuleListForm : Form
    {
        private readonly RuleController controller = new RuleController();

        public RuleListForm()
        {
            InitializeComponent();
            LoadRules();
        }

        private void LoadRules()
        {
            var table = controller.GetRuleTable();
            dataGridView1.DataSource = table;

            dataGridView1.Columns["RuleId"].HeaderText = "ID";
            dataGridView1.Columns["WhatToGet"].HeaderText = "Что получить";
            dataGridView1.Columns["Instruction"].HeaderText = "Инструкция";
            dataGridView1.Columns["DeadlineEvent"].HeaderText = "Отсчёт от";
            dataGridView1.Columns["DeadlineDays"].HeaderText = "Дней";
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
            int ruleId = (int)dataGridView1.CurrentRow.Cells["RuleId"].Value;
            using var f = new RuleInputForm(ruleId);
            f.ShowDialog();
            LoadRules();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            int ruleId = (int)dataGridView1.CurrentRow.Cells["RuleId"].Value;
            if (MessageBox.Show($"Удалить правило #{ruleId}?", "Подтвердите",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                controller.DeleteRule(ruleId);
                LoadRules();
            }
        }
    }
}

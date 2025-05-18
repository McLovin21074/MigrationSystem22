namespace MigrationSystem22.View
{
    partial class RuleListForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridView1;
        private Button btnAdd, btnEdit, btnDelete;

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();

            // dataGridView1
            dataGridView1.Location = new System.Drawing.Point(12, 12);
            dataGridView1.Size = new System.Drawing.Size(600, 300);
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoGenerateColumns = true;

            // btnAdd
            btnAdd.Text = "Добавить";
            btnAdd.Location = new System.Drawing.Point(630, 30);
            btnAdd.Click += btnAdd_Click;

            // btnEdit
            btnEdit.Text = "Редактировать";
            btnEdit.Location = new System.Drawing.Point(630, 80);
            btnEdit.Click += btnEdit_Click;

            // btnDelete
            btnDelete.Text = "Удалить";
            btnDelete.Location = new System.Drawing.Point(630, 130);
            btnDelete.Click += btnDelete_Click;

            // RuleListForm
            Text = "Список правил";
            ClientSize = new System.Drawing.Size(760, 330);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;

            Controls.Add(dataGridView1);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }
    }
}

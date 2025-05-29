namespace MigrationSystem22.View
{
    partial class RuleListForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridView1;
        private Button btnAdd, btnEdit, btnDelete;

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeight = 29;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(600, 300);
            dataGridView1.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(630, 30);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(118, 44);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Добавить";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(630, 80);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(118, 44);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Редактировать";
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(630, 130);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(118, 43);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Удалить";
            btnDelete.Click += btnDelete_Click;
            // 
            // RuleListForm
            // 
            ClientSize = new Size(760, 330);
            Controls.Add(dataGridView1);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "RuleListForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Список правил";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }
    }
}

using MigrationSystem22.Models;
using MigrationSystem22.Controllers;
using System.Windows.Forms;


namespace MigrationSystem22.View
{
    public partial class RuleInputForm : Form
    {
        private List<RuleConditionEntity> _conditions = new();

        public RuleInputForm()
        {
            InitializeComponent();

            comboBoxField.Items.AddRange(new[]
{
    "Country", "EntryGoal", "Qualification", "IsInProgram", "WasMigrant", "HasPatent", "HasWorkPermit"
});

            comboBoxOperator.Items.AddRange(new[]
            {
    "=", "!=", "IN", "NOT IN"
});

            comboBoxDeadlineEvent.Items.AddRange(new[]
            {
    "entry_date", "registration_date", "patent_issue_date"
});
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddCondition_Click(object sender, EventArgs e)
        {
            string field = comboBoxField.SelectedItem?.ToString();
            string op = comboBoxOperator.SelectedItem?.ToString();
            string value = textBoxConditionValue.Text.Trim();

            if (string.IsNullOrEmpty(field) || string.IsNullOrEmpty(op) || string.IsNullOrEmpty(value))
            {
                MessageBox.Show("Заполните поле, оператор и значение");
                return;
            }

            var condition = new RuleConditionEntity
            {
                FieldName = field,
                Operator = op,
                Value = value
            };

            _conditions.Add(condition);
            RefreshConditionList();
        }

        private void RefreshConditionList()
        {
            listViewConditions.Items.Clear();
            listViewConditions.View = System.Windows.Forms.View.Details;

            if (listViewConditions.Columns.Count == 0)
            {
                listViewConditions.Columns.Add("Поле");
                listViewConditions.Columns.Add("Оператор");
                listViewConditions.Columns.Add("Значение");
            }

            foreach (var cond in _conditions)
            {
                var item = new ListViewItem(cond.FieldName);
                item.SubItems.Add(cond.Operator);
                item.SubItems.Add(cond.Value);
                listViewConditions.Items.Add(item);
            }

            listViewConditions.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buttonRemoveCondition_Click(object sender, EventArgs e)
        {
            if (listViewConditions.SelectedItems.Count > 0)
            {
                int index = listViewConditions.SelectedItems[0].Index;
                _conditions.RemoveAt(index);
                RefreshConditionList();
            }
        }

        private void buttonSaveRule_Click(object sender, EventArgs e)
        {
            string whatToGet = textBoxWhatToGet.Text.Trim();
            string instruction = textBoxInstruction.Text.Trim();    
            int deadlineDays = (int)numericDeadlineDays.Value;
            var deadlineEventStr = comboBoxDeadlineEvent.SelectedItem?.ToString();
            if (!Enum.TryParse<ControlDateType>(deadlineEventStr, out var deadlineEventEnum))
            {
                MessageBox.Show("Неверное значение для срока выполнения.");
                return;
            }


            if (string.IsNullOrEmpty(whatToGet) || string.IsNullOrEmpty(instruction) || comboBoxDeadlineEvent.SelectedItem == null)
            {
                MessageBox.Show("Заполните все основные поля.");
                return;
            }

            if (_conditions.Count == 0)
            {
                MessageBox.Show("Добавьте хотя бы одно условие.");
                return;
            }

            try
            {
                var controller = new RuleController();
                controller.SaveRule(whatToGet, instruction, deadlineEventEnum, deadlineDays, _conditions);

                MessageBox.Show("Правило успешно сохранено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message + "\n\n" + ex.InnerException?.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonAddCondition_Click_1(object sender, EventArgs e)
        {

        }
    }
}

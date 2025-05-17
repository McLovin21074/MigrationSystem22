using MigrationSystem22.Controllers;
using MigrationSystem22.Models;

namespace MigrationSystem22.View
{
    public partial class RuleInputForm : Form
    {
        private readonly RuleController controller = new RuleController();

        public RuleInputForm()
        {
            InitializeComponent();

            controller.AddRule();

            comboBoxField.Items.AddRange(new[]
            {
                "Country", "EntryGoal", "Qualification",
                "IsInProgram", "WasMigrant", "HasPatent", "HasWorkPermit"
            });
            comboBoxOperator.Items.AddRange(new[] { "=", "!=", "IN", "NOT IN" });
            comboBoxDeadlineEvent.Items.AddRange(Enum.GetNames(typeof(ControlDateType)));

            comboBoxField.SelectedIndex = 0;
            comboBoxOperator.SelectedIndex = 0;
            comboBoxDeadlineEvent.SelectedIndex = 0;

            comboBoxGroupSelector.Items.Add("Группа 1");
            comboBoxGroupSelector.SelectedIndex = 0;

            UpdateCurrentGroupLabel();
            RefreshConditionList();
        }

        private void buttonNewGroup_Click(object sender, EventArgs e)
        {
            controller.NewConditionGroup();
            comboBoxGroupSelector.Items.Add($"Группа {controller.Groups.Count}");
            comboBoxGroupSelector.SelectedIndex = controller.Groups.Count - 1;

            UpdateCurrentGroupLabel();
            RefreshConditionList();
        }

        private void comboBoxGroupSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCurrentGroupLabel();
            RefreshConditionList();
        }

        private void UpdateCurrentGroupLabel()
        {
            labelCurrentGroup.Text =
                $"Текущая группа: {comboBoxGroupSelector.SelectedIndex + 1}";
        }

        private void buttonAddCondition_Click(object sender, EventArgs e)
        {
            var field = comboBoxField.SelectedItem?.ToString();
            var op = comboBoxOperator.SelectedItem?.ToString();
            var val = textBoxConditionValue.Text.Trim();

            if (string.IsNullOrEmpty(field) ||
                string.IsNullOrEmpty(op) ||
                string.IsNullOrEmpty(val))
            {
                MessageBox.Show("Заполните поле, оператор и значение");
                return;
            }

            controller.AddCondition(field, op, val);
            textBoxConditionValue.Clear();
            RefreshConditionList();
        }

        private void RefreshConditionList()
        {
            listViewConditions.Clear();
            listViewConditions.View = System.Windows.Forms.View.Details;

            if (listViewConditions.Columns.Count == 0)
            {
                listViewConditions.Columns.Add("Группа");
                listViewConditions.Columns.Add("Поле");
                listViewConditions.Columns.Add("Оператор");
                listViewConditions.Columns.Add("Значение");
            }

            var groups = controller.Groups;
            if (groups == null) return;

            for (int gi = 0; gi < groups.Count; gi++)
            {
                var group = groups[gi];
                for (int ci = 0; ci < group.Count; ci++)
                {
                    var cond = group[ci];
                    var item = new ListViewItem($"Группа {gi + 1}")
                    {
                        Tag = Tuple.Create(gi, ci)
                    };
                    item.SubItems.Add(cond.FieldName);
                    item.SubItems.Add(cond.Operator);
                    item.SubItems.Add(cond.Value);
                    listViewConditions.Items.Add(item);
                }
            }

            listViewConditions.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buttonRemoveCondition_Click(object sender, EventArgs e)
        {
            if (listViewConditions.SelectedItems.Count == 0)
                return;

            var item = listViewConditions.SelectedItems[0];
            if (item.Tag is Tuple<int, int> pos)
            {
                int groupIndex = pos.Item1;
                int conditionIndex = pos.Item2;
                controller.RemoveCondition(groupIndex, conditionIndex);
                RefreshConditionList();
            }
        }

        private void buttonSaveRule_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxWhatToGet.Text) ||
                string.IsNullOrWhiteSpace(textBoxInstruction.Text))
            {
                MessageBox.Show("Заполните «Что получить» и «Инструкцию»");
                return;
            }

            if (!Enum.TryParse<ControlDateType>(
                    comboBoxDeadlineEvent.SelectedItem.ToString(),
                    out var ev))
            {
                MessageBox.Show("Неверный тип дедлайна");
                return;
            }
            controller.SetDeadline(ev, (int)numericDeadlineDays.Value);

            try
            {
                controller.Save();
                MessageBox.Show("Правило сохранено!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении:\n" + ex.Message,
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label6_Click(object sender, EventArgs e) { }
    }
}

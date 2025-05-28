using System;
using System.Linq;
using System.Windows.Forms;
using MigrationSystem22.Controllers;
using MigrationSystem22.Models;

namespace MigrationSystem22.View
{
    public partial class RuleInputForm : Form
    {
        private readonly RuleController controller;

        public RuleInputForm(int? ruleId = null)
        {
            InitializeComponent();
            controller = new RuleController();

            if (ruleId.HasValue)
                controller.LoadRule(ruleId.Value);
            else
                controller.AddRule();

            textBoxWhatToGet.Text = controller.DraftWhatToGet;
            textBoxInstruction.Text = controller.DraftInstruction;

            comboBoxDeadlineEvent.Items.AddRange(Enum.GetNames(typeof(ControlDateType)));
            comboBoxDeadlineEvent.SelectedItem = controller.DraftDeadlineEvent.ToString();
            var dDays = controller.DraftDeadlineDays;
            if (dDays < numericDeadlineDays.Minimum || dDays > numericDeadlineDays.Maximum)
                dDays = (int)numericDeadlineDays.Minimum;
            numericDeadlineDays.Value = dDays;

            var fields = controller.AvailableFields
                          .Select(f => new {
                              Key = f,
                              Value = controller.GetFieldDefinition(f).DisplayName
                          })
                          .ToList();
            comboBoxField.DataSource = fields;
            comboBoxField.DisplayMember = "Value";
            comboBoxField.ValueMember = "Key";
            comboBoxField.SelectedIndexChanged += comboBoxField_SelectedIndexChanged;
            comboBoxField.SelectedIndex = 0;

            comboBoxGroupSelector.Items.Clear();
            for (int i = 0; i < controller.Groups.Count; i++)
                comboBoxGroupSelector.Items.Add($"Группа {i + 1}");
            comboBoxGroupSelector.SelectedIndexChanged += comboBoxGroupSelector_SelectedIndexChanged;
            comboBoxGroupSelector.SelectedIndex = 0;

            RefreshConditionList();
        }

        private void comboBoxField_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fieldKey = comboBoxField.SelectedValue.ToString();
            ApplyFieldDefinition(fieldKey);
        }

        private void ApplyFieldDefinition(string fieldName)
        {
            var def = controller.GetFieldDefinition(fieldName);

            comboBoxOperator.Items.Clear();
            comboBoxOperator.Items.AddRange(def.AllowedOperators);
            comboBoxOperator.SelectedIndex = 0;

            if (def.AllowedValues != null)
            {
                comboBoxConditionValue.Visible = true;
                textBoxConditionValue.Visible = false;
                comboBoxConditionValue.Items.Clear();
                comboBoxConditionValue.Items.AddRange(def.AllowedValues);
                comboBoxConditionValue.SelectedIndex = 0;
            }
            else
            {
                comboBoxConditionValue.Visible = false;
                textBoxConditionValue.Visible = true;
                textBoxConditionValue.Clear();
            }
        }

        private void buttonAddCondition_Click(object sender, EventArgs e)
        {
            var fieldKey = comboBoxField.SelectedValue.ToString();
            var def = controller.GetFieldDefinition(fieldKey);
            var op = comboBoxOperator.SelectedItem.ToString();

            string val = def.AllowedValues != null
                ? comboBoxConditionValue.SelectedItem.ToString()
                : textBoxConditionValue.Text.Trim();

            controller.AddCondition(fieldKey, op, val);
            RefreshConditionList();
        }

        private void buttonNewGroup_Click(object sender, EventArgs e)
        {
            controller.NewConditionGroup();
            comboBoxGroupSelector.Items.Add($"Группа {controller.Groups.Count}");
            comboBoxGroupSelector.SelectedIndex = controller.Groups.Count - 1;
            RefreshConditionList();
        }

        private void comboBoxGroupSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.SetCurrentConditionGroup(comboBoxGroupSelector.SelectedIndex);
            RefreshConditionList();
        }

        private void buttonRemoveCondition_Click(object sender, EventArgs e)
        {
            if (listViewConditions.SelectedItems.Count == 0) return;
            if (listViewConditions.SelectedItems[0].Tag is Tuple<int, int> pos)
            {
                controller.RemoveCondition(pos.Item1, pos.Item2);
                RefreshConditionList();
            }
        }

        private void buttonSaveRule_Click(object sender, EventArgs e)
        {
            var w = textBoxWhatToGet.Text.Trim();
            var ins = textBoxInstruction.Text.Trim();

            bool hasConditions = controller.Groups.Any(g => g.Count > 0);
            if (string.IsNullOrEmpty(w)
                || string.IsNullOrEmpty(ins)
                || !hasConditions)
            {
                MessageBox.Show(
                    "Нельзя сохранять пустое правило. Нужно заполнить поля «Что нужно получить», «Инструкция» и добавьте хотя бы одно условие.",
                    "Ошибка валидации",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            controller.SetMetadata(w, ins);

            if (!Enum.TryParse<ControlDateType>(
                    comboBoxDeadlineEvent.SelectedItem.ToString(),
                    out var ev))
            {
                MessageBox.Show("Неверное событие отсчёта");
                return;
            }
            controller.SetDeadline(ev, (int)numericDeadlineDays.Value);

            controller.Save();
            MessageBox.Show("Правило сохранено!");
            Close();
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
                for (int ci = 0; ci < groups[gi].Count; ci++)
                {
                    var c = groups[gi][ci];
                    var item = new ListViewItem($"Группа {gi + 1}")
                    { Tag = Tuple.Create(gi, ci) };
                    var disp = controller.GetFieldDefinition(c.FieldName).DisplayName;
                    item.SubItems.Add(disp);
                    item.SubItems.Add(c.Operator);
                    item.SubItems.Add(c.Value);
                    listViewConditions.Items.Add(item);
                }

            listViewConditions.AutoResizeColumns(
                ColumnHeaderAutoResizeStyle.HeaderSize
            );
        }
    }
}

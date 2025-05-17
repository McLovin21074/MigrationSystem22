using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
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

            comboBoxField.Items.AddRange(controller.AvailableFields.ToArray());
            comboBoxField.SelectedIndexChanged += comboBoxField_SelectedIndexChanged;
            comboBoxField.SelectedIndex = 0;

            ApplyFieldDefinition(comboBoxField.SelectedItem!.ToString());

            comboBoxDeadlineEvent.Items.AddRange(Enum.GetNames(typeof(ControlDateType)));
            comboBoxDeadlineEvent.SelectedIndex = 0;

            comboBoxGroupSelector.Items.Clear();
            comboBoxGroupSelector.Items.Add("Группа 1");
            comboBoxGroupSelector.SelectedIndex = 0;
            comboBoxGroupSelector.SelectedIndexChanged += comboBoxGroupSelector_SelectedIndexChanged;

            RefreshConditionList();
        }

        private void comboBoxField_SelectedIndexChanged(object sender, EventArgs e)
        {
            var field = comboBoxField.SelectedItem!.ToString();
            ApplyFieldDefinition(field);
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
            var field = comboBoxField.SelectedItem!.ToString();
            var def = controller.GetFieldDefinition(field);
            var op = comboBoxOperator.SelectedItem!.ToString();

            string val = def.AllowedValues != null
                ? comboBoxConditionValue.SelectedItem!.ToString()
                : textBoxConditionValue.Text.Trim();

            if (!def.AllowedOperators.Contains(op))
            {
                MessageBox.Show($"Оператор «{op}» недопустим для поля {field}");
                return;
            }
            if (def.FieldType == typeof(bool) && !bool.TryParse(val, out _))
            {
                MessageBox.Show("Значение должно быть True или False");
                return;
            }
            if (def.FieldType == typeof(DateTime) && !DateTime.TryParse(val, out _))
            {
                MessageBox.Show("Введите корректную дату");
                return;
            }

            controller.AddCondition(field, op, val);
            RefreshConditionList();
        }

        private void buttonNewGroup_Click(object sender, EventArgs e)
        {
            controller.NewConditionGroup();
            comboBoxGroupSelector.Items.Add($"Группа {controller.Groups.Count}");
            comboBoxGroupSelector.SelectedIndex = controller.Groups.Count - 1;
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
            var whatToGet = textBoxWhatToGet.Text.Trim();
            var instruction = textBoxInstruction.Text.Trim();
            if (string.IsNullOrEmpty(whatToGet) || string.IsNullOrEmpty(instruction))
            {
                MessageBox.Show("Заполните оба поля: «Что нужно получить» и «Инструкция»");
                return;
            }
            controller.SetMetadata(whatToGet, instruction);

            if (!Enum.TryParse<ControlDateType>(
                    comboBoxDeadlineEvent.SelectedItem!.ToString(),
                    out var ev))
            {
                MessageBox.Show("Неверное событие отсчёта");
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

        private void comboBoxGroupSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                var grp = groups[gi];
                for (int ci = 0; ci < grp.Count; ci++)
                {
                    var cond = grp[ci];
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

            listViewConditions.AutoResizeColumns(
                ColumnHeaderAutoResizeStyle.HeaderSize
            );
        }

        private void label6_Click(object sender, EventArgs e) { }
    }
}

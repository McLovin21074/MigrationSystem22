namespace MigrationSystem22.View
{
    partial class RuleInputForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label label1;
        private TextBox textBoxWhatToGet;
        private Label label2;
        private TextBox textBoxInstruction;
        private Label label3;
        private ComboBox comboBoxDeadlineEvent;
        private Label label4;
        private NumericUpDown numericDeadlineDays;
        private Label label5;
        private ComboBox comboBoxField;
        private Label label6;
        private ComboBox comboBoxOperator;
        private Label label7;
        private TextBox textBoxConditionValue;
        private Button buttonAddCondition;
        private ListView listViewConditions;
        private Button buttonRemoveCondition;
        private Button buttonSaveRule;
        private Button buttonNewGroup;
        private Label labelCurrentGroup;
        private ComboBox comboBoxGroupSelector;
        private ComboBox comboBoxConditionValue;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            textBoxWhatToGet = new TextBox();
            label2 = new Label();
            textBoxInstruction = new TextBox();
            label3 = new Label();
            comboBoxDeadlineEvent = new ComboBox();
            label4 = new Label();
            numericDeadlineDays = new NumericUpDown();
            label5 = new Label();
            comboBoxField = new ComboBox();
            label6 = new Label();
            comboBoxOperator = new ComboBox();
            label7 = new Label();
            textBoxConditionValue = new TextBox();
            comboBoxConditionValue = new ComboBox();
            buttonAddCondition = new Button();
            listViewConditions = new ListView();
            buttonRemoveCondition = new Button();
            buttonSaveRule = new Button();
            buttonNewGroup = new Button();
            labelCurrentGroup = new Label();
            comboBoxGroupSelector = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)numericDeadlineDays).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(29, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(151, 20);
            label1.TabIndex = 0;
            label1.Text = "Что нужно получить";
            // 
            // textBoxWhatToGet
            // 
            textBoxWhatToGet.Location = new System.Drawing.Point(34, 40);
            textBoxWhatToGet.Name = "textBoxWhatToGet";
            textBoxWhatToGet.Size = new System.Drawing.Size(306, 27);
            textBoxWhatToGet.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(35, 93);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(91, 20);
            label2.TabIndex = 2;
            label2.Text = "Инструкция";
            // 
            // textBoxInstruction
            // 
            textBoxInstruction.Location = new System.Drawing.Point(35, 134);
            textBoxInstruction.Multiline = true;
            textBoxInstruction.Name = "textBoxInstruction";
            textBoxInstruction.Size = new System.Drawing.Size(274, 131);
            textBoxInstruction.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(23, 287);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(118, 20);
            label3.TabIndex = 4;
            label3.Text = "Отсчёт срока от";
            // 
            // comboBoxDeadlineEvent
            // 
            comboBoxDeadlineEvent.FormattingEnabled = true;
            comboBoxDeadlineEvent.Location = new System.Drawing.Point(29, 334);
            comboBoxDeadlineEvent.Name = "comboBoxDeadlineEvent";
            comboBoxDeadlineEvent.Size = new System.Drawing.Size(151, 28);
            comboBoxDeadlineEvent.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(29, 397);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(91, 20);
            label4.TabIndex = 6;
            label4.Text = "Срок (дней)";
            // 
            // numericDeadlineDays
            // 
            numericDeadlineDays.Location = new System.Drawing.Point(30, 432);
            numericDeadlineDays.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericDeadlineDays.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericDeadlineDays.Name = "numericDeadlineDays";
            numericDeadlineDays.Size = new System.Drawing.Size(150, 27);
            numericDeadlineDays.TabIndex = 7;
            numericDeadlineDays.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(522, 24);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(45, 20);
            label5.TabIndex = 8;
            label5.Text = "Поле";
            // 
            // comboBoxField
            // 
            comboBoxField.FormattingEnabled = true;
            comboBoxField.Location = new System.Drawing.Point(524, 64);
            comboBoxField.Name = "comboBoxField";
            comboBoxField.Size = new System.Drawing.Size(151, 28);
            comboBoxField.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(720, 24);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(78, 20);
            label6.TabIndex = 10;
            label6.Text = "Оператор";
            // 
            // comboBoxOperator
            // 
            comboBoxOperator.FormattingEnabled = true;
            comboBoxOperator.Location = new System.Drawing.Point(729, 65);
            comboBoxOperator.Name = "comboBoxOperator";
            comboBoxOperator.Size = new System.Drawing.Size(151, 28);
            comboBoxOperator.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(916, 30);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(76, 20);
            label7.TabIndex = 12;
            label7.Text = "Значение";
            // 
            // textBoxConditionValue
            // 
            textBoxConditionValue.Location = new System.Drawing.Point(917, 66);
            textBoxConditionValue.Name = "textBoxConditionValue";
            textBoxConditionValue.Size = new System.Drawing.Size(147, 27);
            textBoxConditionValue.TabIndex = 13;
            // 
            // comboBoxConditionValue
            // 
            comboBoxConditionValue.FormattingEnabled = true;
            comboBoxConditionValue.Location = new System.Drawing.Point(913, 63);
            comboBoxConditionValue.Name = "comboBoxConditionValue";
            comboBoxConditionValue.Size = new System.Drawing.Size(151, 28);
            comboBoxConditionValue.TabIndex = 21;
            comboBoxConditionValue.Visible = false;
            // 
            // buttonAddCondition
            // 
            buttonAddCondition.Location = new System.Drawing.Point(906, 118);
            buttonAddCondition.Name = "buttonAddCondition";
            buttonAddCondition.Size = new System.Drawing.Size(157, 29);
            buttonAddCondition.TabIndex = 14;
            buttonAddCondition.Text = "Добавить условие";
            buttonAddCondition.UseVisualStyleBackColor = true;
            buttonAddCondition.Click += buttonAddCondition_Click;
            // 
            // listViewConditions
            // 
            listViewConditions.Location = new System.Drawing.Point(466, 232);
            listViewConditions.Name = "listViewConditions";
            listViewConditions.Size = new System.Drawing.Size(414, 121);
            listViewConditions.TabIndex = 15;
            listViewConditions.UseCompatibleStateImageBehavior = false;
            // 
            // buttonRemoveCondition
            // 
            buttonRemoveCondition.Location = new System.Drawing.Point(772, 118);
            buttonRemoveCondition.Name = "buttonRemoveCondition";
            buttonRemoveCondition.Size = new System.Drawing.Size(94, 29);
            buttonRemoveCondition.TabIndex = 16;
            buttonRemoveCondition.Text = "Удалить условие";
            buttonRemoveCondition.UseVisualStyleBackColor = true;
            buttonRemoveCondition.Click += buttonRemoveCondition_Click;
            // 
            // buttonSaveRule
            // 
            buttonSaveRule.Location = new System.Drawing.Point(1023, 374);
            buttonSaveRule.Name = "buttonSaveRule";
            buttonSaveRule.Size = new System.Drawing.Size(130, 48);
            buttonSaveRule.TabIndex = 17;
            buttonSaveRule.Text = "Сохранить правило";
            buttonSaveRule.UseVisualStyleBackColor = true;
            buttonSaveRule.Click += buttonSaveRule_Click;
            // 
            // buttonNewGroup
            // 
            buttonNewGroup.Location = new System.Drawing.Point(929, 178);
            buttonNewGroup.Name = "buttonNewGroup";
            buttonNewGroup.Size = new System.Drawing.Size(113, 62);
            buttonNewGroup.TabIndex = 18;
            buttonNewGroup.Text = "Новая группа условий";
            buttonNewGroup.UseVisualStyleBackColor = true;
            buttonNewGroup.Click += buttonNewGroup_Click;
            // 
            // labelCurrentGroup
            // 
            labelCurrentGroup.AutoSize = true;
            labelCurrentGroup.Location = new System.Drawing.Point(590, 198);
            labelCurrentGroup.Name = "labelCurrentGroup";
            labelCurrentGroup.Size = new System.Drawing.Size(134, 20);
            labelCurrentGroup.TabIndex = 19;
            labelCurrentGroup.Text = "Текущая группа: 1";
            // 
            // comboBoxGroupSelector
            // 
            comboBoxGroupSelector.FormattingEnabled = true;
            comboBoxGroupSelector.Location = new System.Drawing.Point(590, 374);
            comboBoxGroupSelector.Name = "comboBoxGroupSelector";
            comboBoxGroupSelector.Size = new System.Drawing.Size(151, 28);
            comboBoxGroupSelector.TabIndex = 20;
            comboBoxGroupSelector.Text = "Выберите группу";
            // 
            // RuleInputForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1353, 492);
            Controls.Add(comboBoxConditionValue);
            Controls.Add(comboBoxGroupSelector);
            Controls.Add(labelCurrentGroup);
            Controls.Add(buttonNewGroup);
            Controls.Add(buttonSaveRule);
            Controls.Add(buttonRemoveCondition);
            Controls.Add(listViewConditions);
            Controls.Add(buttonAddCondition);
            Controls.Add(textBoxConditionValue);
            Controls.Add(label7);
            Controls.Add(comboBoxOperator);
            Controls.Add(label6);
            Controls.Add(comboBoxField);
            Controls.Add(label5);
            Controls.Add(numericDeadlineDays);
            Controls.Add(label4);
            Controls.Add(comboBoxDeadlineEvent);
            Controls.Add(label3);
            Controls.Add(textBoxInstruction);
            Controls.Add(label2);
            Controls.Add(textBoxWhatToGet);
            Controls.Add(label1);
            Name = "RuleInputForm";
            Text = "RuleInputForm";
            ((System.ComponentModel.ISupportInitialize)numericDeadlineDays).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

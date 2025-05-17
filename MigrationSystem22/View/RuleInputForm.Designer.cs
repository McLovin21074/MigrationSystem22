namespace MigrationSystem22.View
{
    partial class RuleInputForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
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
            buttonAddCondition = new Button();
            listViewConditions = new ListView();
            buttonRemoveCondition = new Button();
            buttonSaveRule = new Button();
            buttonNewGroup = new Button();
            labelCurrentGroup = new Label();
            comboBoxGroupSelector = new ComboBox();
            comboBoxConditionValue = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)numericDeadlineDays).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 9);
            label1.Name = "label1";
            label1.Size = new Size(151, 20);
            label1.TabIndex = 0;
            label1.Text = "Что нужно получить";
            // 
            // textBoxWhatToGet
            // 
            textBoxWhatToGet.Location = new Point(34, 40);
            textBoxWhatToGet.Name = "textBoxWhatToGet";
            textBoxWhatToGet.Size = new Size(125, 27);
            textBoxWhatToGet.TabIndex = 1;
            textBoxWhatToGet.Text = "Получить";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 93);
            label2.Name = "label2";
            label2.Size = new Size(91, 20);
            label2.TabIndex = 2;
            label2.Text = "Инструкция";
            // 
            // textBoxInstruction
            // 
            textBoxInstruction.Location = new Point(35, 134);
            textBoxInstruction.Name = "textBoxInstruction";
            textBoxInstruction.Size = new Size(31, 27);
            textBoxInstruction.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 199);
            label3.Name = "label3";
            label3.Size = new Size(118, 20);
            label3.TabIndex = 4;
            label3.Text = "Отсчёт срока от";
            // 
            // comboBoxDeadlineEvent
            // 
            comboBoxDeadlineEvent.FormattingEnabled = true;
            comboBoxDeadlineEvent.Location = new Point(35, 246);
            comboBoxDeadlineEvent.Name = "comboBoxDeadlineEvent";
            comboBoxDeadlineEvent.Size = new Size(151, 28);
            comboBoxDeadlineEvent.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(35, 309);
            label4.Name = "label4";
            label4.Size = new Size(91, 20);
            label4.TabIndex = 6;
            label4.Text = "Срок (дней)";
            // 
            // numericDeadlineDays
            // 
            numericDeadlineDays.Location = new Point(36, 344);
            numericDeadlineDays.Maximum = new decimal(new int[] { 365, 0, 0, 0 });
            numericDeadlineDays.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericDeadlineDays.Name = "numericDeadlineDays";
            numericDeadlineDays.Size = new Size(150, 27);
            numericDeadlineDays.TabIndex = 7;
            numericDeadlineDays.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(522, 24);
            label5.Name = "label5";
            label5.Size = new Size(45, 20);
            label5.TabIndex = 8;
            label5.Text = "Поле";
            // 
            // comboBoxField
            // 
            comboBoxField.FormattingEnabled = true;
            comboBoxField.Location = new Point(524, 64);
            comboBoxField.Name = "comboBoxField";
            comboBoxField.Size = new Size(151, 28);
            comboBoxField.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(720, 24);
            label6.Name = "label6";
            label6.Size = new Size(78, 20);
            label6.TabIndex = 10;
            label6.Text = "Оператор";
            label6.Click += label6_Click;
            // 
            // comboBoxOperator
            // 
            comboBoxOperator.FormattingEnabled = true;
            comboBoxOperator.Location = new Point(729, 65);
            comboBoxOperator.Name = "comboBoxOperator";
            comboBoxOperator.Size = new Size(151, 28);
            comboBoxOperator.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(916, 30);
            label7.Name = "label7";
            label7.Size = new Size(76, 20);
            label7.TabIndex = 12;
            label7.Text = "Значение";
            // 
            // textBoxConditionValue
            // 
            textBoxConditionValue.Location = new Point(925, 71);
            textBoxConditionValue.Name = "textBoxConditionValue";
            textBoxConditionValue.Size = new Size(125, 27);
            textBoxConditionValue.TabIndex = 13;
            // 
            // buttonAddCondition
            // 
            buttonAddCondition.Location = new Point(906, 118);
            buttonAddCondition.Name = "buttonAddCondition";
            buttonAddCondition.Size = new Size(157, 29);
            buttonAddCondition.TabIndex = 14;
            buttonAddCondition.Text = "Добавить условие";
            buttonAddCondition.UseVisualStyleBackColor = true;
            buttonAddCondition.Click += buttonAddCondition_Click;
            // 
            // listViewConditions
            // 
            listViewConditions.Location = new Point(590, 232);
            listViewConditions.Name = "listViewConditions";
            listViewConditions.Size = new Size(151, 121);
            listViewConditions.TabIndex = 15;
            listViewConditions.UseCompatibleStateImageBehavior = false;
            // 
            // buttonRemoveCondition
            // 
            buttonRemoveCondition.Location = new Point(925, 324);
            buttonRemoveCondition.Name = "buttonRemoveCondition";
            buttonRemoveCondition.Size = new Size(94, 29);
            buttonRemoveCondition.TabIndex = 16;
            buttonRemoveCondition.Text = "Удалить условие";
            buttonRemoveCondition.UseVisualStyleBackColor = true;
            buttonRemoveCondition.Click += buttonRemoveCondition_Click;
            // 
            // buttonSaveRule
            // 
            buttonSaveRule.Location = new Point(1206, 386);
            buttonSaveRule.Name = "buttonSaveRule";
            buttonSaveRule.Size = new Size(94, 29);
            buttonSaveRule.TabIndex = 17;
            buttonSaveRule.Text = "Сохранить правило";
            buttonSaveRule.UseVisualStyleBackColor = true;
            buttonSaveRule.Click += buttonSaveRule_Click;
            // 
            // buttonNewGroup
            // 
            buttonNewGroup.Location = new Point(906, 178);
            buttonNewGroup.Name = "buttonNewGroup";
            buttonNewGroup.Size = new Size(113, 62);
            buttonNewGroup.TabIndex = 18;
            buttonNewGroup.Text = "Новая группа условий";
            buttonNewGroup.UseVisualStyleBackColor = true;
            buttonNewGroup.Click += buttonNewGroup_Click;
            // 
            // labelCurrentGroup
            // 
            labelCurrentGroup.AutoSize = true;
            labelCurrentGroup.Location = new Point(590, 198);
            labelCurrentGroup.Name = "labelCurrentGroup";
            labelCurrentGroup.Size = new Size(134, 20);
            labelCurrentGroup.TabIndex = 19;
            labelCurrentGroup.Text = "Текущая группа: 1";
            // 
            // comboBoxGroupSelector
            // 
            comboBoxGroupSelector.FormattingEnabled = true;
            comboBoxGroupSelector.Location = new Point(590, 374);
            comboBoxGroupSelector.Name = "comboBoxGroupSelector";
            comboBoxGroupSelector.Size = new Size(151, 28);
            comboBoxGroupSelector.TabIndex = 20;
            comboBoxGroupSelector.Text = "Выберите группу";
            comboBoxGroupSelector.SelectedIndexChanged += comboBoxGroupSelector_SelectedIndexChanged;
            // 
            // comboBoxConditionValue
            // 
            comboBoxConditionValue.FormattingEnabled = true;
            comboBoxConditionValue.Location = new Point(925, 71);
            comboBoxConditionValue.Name = "comboBoxConditionValue";
            comboBoxConditionValue.Size = new Size(151, 28);
            comboBoxConditionValue.TabIndex = 21;
            comboBoxConditionValue.Visible = false;
            // 
            // RuleInputForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1353, 492);
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

        #endregion

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
    }
}
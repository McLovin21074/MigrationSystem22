namespace MigrationSystem22.View
{
    partial class UserInputForm
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
            labelEntryDate = new Label();
            dateTimePickerEntryDate = new DateTimePicker();
            labelCountry = new Label();
            checkBoxQualification = new CheckBox();
            checkBoxIsInProgram = new CheckBox();
            checkBoxWasMigrant = new CheckBox();
            checkBoxHasWorkPermit = new CheckBox();
            checkBoxHasPatent = new CheckBox();
            buttonSave = new Button();
            comboBoxCountry = new ComboBox();
            comboBoxEntryGoal = new ComboBox();
            labelEntryGoal = new Label();
            dateTimePickerRegistrationDate = new DateTimePicker();
            dateTimePickerPatentIssueDate = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // labelEntryDate
            // 
            labelEntryDate.AutoSize = true;
            labelEntryDate.Location = new Point(57, 19);
            labelEntryDate.Name = "labelEntryDate";
            labelEntryDate.Size = new Size(93, 20);
            labelEntryDate.TabIndex = 0;
            labelEntryDate.Text = "Дата въезда";
            // 
            // dateTimePickerEntryDate
            // 
            dateTimePickerEntryDate.Location = new Point(57, 62);
            dateTimePickerEntryDate.Name = "dateTimePickerEntryDate";
            dateTimePickerEntryDate.Size = new Size(250, 27);
            dateTimePickerEntryDate.TabIndex = 1;
            // 
            // labelCountry
            // 
            labelCountry.AutoSize = true;
            labelCountry.Location = new Point(57, 122);
            labelCountry.Name = "labelCountry";
            labelCountry.Size = new Size(58, 20);
            labelCountry.TabIndex = 2;
            labelCountry.Text = "Страна";
            // 
            // checkBoxQualification
            // 
            checkBoxQualification.AutoSize = true;
            checkBoxQualification.Location = new Point(63, 206);
            checkBoxQualification.Name = "checkBoxQualification";
            checkBoxQualification.Size = new Size(182, 24);
            checkBoxQualification.TabIndex = 4;
            checkBoxQualification.Text = "Квалифицированный";
            checkBoxQualification.UseVisualStyleBackColor = true;
            // 
            // checkBoxIsInProgram
            // 
            checkBoxIsInProgram.AutoSize = true;
            checkBoxIsInProgram.Location = new Point(65, 250);
            checkBoxIsInProgram.Name = "checkBoxIsInProgram";
            checkBoxIsInProgram.Size = new Size(203, 24);
            checkBoxIsInProgram.TabIndex = 5;
            checkBoxIsInProgram.Text = "Участник госпрограммы";
            checkBoxIsInProgram.UseVisualStyleBackColor = true;
            // 
            // checkBoxWasMigrant
            // 
            checkBoxWasMigrant.AutoSize = true;
            checkBoxWasMigrant.Location = new Point(63, 287);
            checkBoxWasMigrant.Name = "checkBoxWasMigrant";
            checkBoxWasMigrant.Size = new Size(121, 24);
            checkBoxWasMigrant.TabIndex = 6;
            checkBoxWasMigrant.Text = "Был на учете";
            checkBoxWasMigrant.UseVisualStyleBackColor = true;
            // 
            // checkBoxHasWorkPermit
            // 
            checkBoxHasWorkPermit.AutoSize = true;
            checkBoxHasWorkPermit.Location = new Point(63, 322);
            checkBoxHasWorkPermit.Name = "checkBoxHasWorkPermit";
            checkBoxHasWorkPermit.Size = new Size(190, 24);
            checkBoxHasWorkPermit.TabIndex = 7;
            checkBoxHasWorkPermit.Text = "Разрешение на работу";
            checkBoxHasWorkPermit.UseVisualStyleBackColor = true;
            // 
            // checkBoxHasPatent
            // 
            checkBoxHasPatent.AutoSize = true;
            checkBoxHasPatent.Location = new Point(71, 365);
            checkBoxHasPatent.Name = "checkBoxHasPatent";
            checkBoxHasPatent.Size = new Size(79, 24);
            checkBoxHasPatent.TabIndex = 8;
            checkBoxHasPatent.Text = "Патент";
            checkBoxHasPatent.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(71, 477);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 29);
            buttonSave.TabIndex = 9;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // comboBoxCountry
            // 
            comboBoxCountry.FormattingEnabled = true;
            comboBoxCountry.Location = new Point(64, 153);
            comboBoxCountry.Name = "comboBoxCountry";
            comboBoxCountry.Size = new Size(151, 28);
            comboBoxCountry.TabIndex = 10;
            // 
            // comboBoxEntryGoal
            // 
            comboBoxEntryGoal.FormattingEnabled = true;
            comboBoxEntryGoal.Location = new Point(63, 424);
            comboBoxEntryGoal.Name = "comboBoxEntryGoal";
            comboBoxEntryGoal.Size = new Size(151, 28);
            comboBoxEntryGoal.TabIndex = 11;
            // 
            // labelEntryGoal
            // 
            labelEntryGoal.AutoSize = true;
            labelEntryGoal.Location = new Point(72, 397);
            labelEntryGoal.Name = "labelEntryGoal";
            labelEntryGoal.Size = new Size(96, 20);
            labelEntryGoal.TabIndex = 12;
            labelEntryGoal.Text = "Цель въезда";
            // 
            // dateTimePickerRegistrationDate
            // 
            dateTimePickerRegistrationDate.Location = new Point(394, 422);
            dateTimePickerRegistrationDate.Name = "dateTimePickerRegistrationDate";
            dateTimePickerRegistrationDate.Size = new Size(250, 27);
            dateTimePickerRegistrationDate.TabIndex = 13;
            // 
            // dateTimePickerPatentIssueDate
            // 
            dateTimePickerPatentIssueDate.Location = new Point(712, 422);
            dateTimePickerPatentIssueDate.Name = "dateTimePickerPatentIssueDate";
            dateTimePickerPatentIssueDate.Size = new Size(250, 27);
            dateTimePickerPatentIssueDate.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(403, 382);
            label1.Name = "label1";
            label1.Size = new Size(134, 20);
            label1.TabIndex = 15;
            label1.Text = "Дата регистрации";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(720, 376);
            label2.Name = "label2";
            label2.Size = new Size(178, 20);
            label2.TabIndex = 16;
            label2.Text = "Дата получения патента";
            // 
            // UserInputForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1265, 547);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateTimePickerPatentIssueDate);
            Controls.Add(dateTimePickerRegistrationDate);
            Controls.Add(labelEntryGoal);
            Controls.Add(comboBoxEntryGoal);
            Controls.Add(comboBoxCountry);
            Controls.Add(buttonSave);
            Controls.Add(checkBoxHasPatent);
            Controls.Add(checkBoxHasWorkPermit);
            Controls.Add(checkBoxWasMigrant);
            Controls.Add(checkBoxIsInProgram);
            Controls.Add(checkBoxQualification);
            Controls.Add(labelCountry);
            Controls.Add(dateTimePickerEntryDate);
            Controls.Add(labelEntryDate);
            Name = "UserInputForm";
            Text = "UserInputForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelEntryDate;
        private DateTimePicker dateTimePickerEntryDate;
        private Label labelCountry;
        private CheckBox checkBoxQualification;
        private CheckBox checkBoxIsInProgram;
        private CheckBox checkBoxWasMigrant;
        private CheckBox checkBoxHasWorkPermit;
        private CheckBox checkBoxHasPatent;
        private Button buttonSave;
        private ComboBox comboBoxCountry;
        private ComboBox comboBoxEntryGoal;
        private Label labelEntryGoal;
        private DateTimePicker dateTimePickerRegistrationDate;
        private DateTimePicker dateTimePickerPatentIssueDate;
        private Label label1;
        private Label label2;
    }
}
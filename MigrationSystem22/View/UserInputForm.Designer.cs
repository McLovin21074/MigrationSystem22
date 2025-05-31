namespace MigrationSystem22.View
{
    partial class UserInputForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageData;
        private System.Windows.Forms.TabPage tabPageRoadMap;
        private System.Windows.Forms.DataGridView dataGridViewRoadMap;
        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.TextBox textBoxFullName;
        private System.Windows.Forms.Label labelEntryDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEntryDate;
        private System.Windows.Forms.Label labelRegistrationDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerRegistrationDate;
        private System.Windows.Forms.Label labelPatentIssueDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerPatentIssueDate;
        private System.Windows.Forms.Label labelCountry;
        private System.Windows.Forms.ComboBox comboBoxCountry;
        private System.Windows.Forms.CheckBox checkBoxQualification;
        private System.Windows.Forms.CheckBox checkBoxIsInProgram;
        private System.Windows.Forms.CheckBox checkBoxWasMigrant;
        private System.Windows.Forms.CheckBox checkBoxHasWorkPermit;
        private System.Windows.Forms.CheckBox checkBoxHasPatent;
        private System.Windows.Forms.Label labelEntryGoal;
        private System.Windows.Forms.ComboBox comboBoxEntryGoal;
        private System.Windows.Forms.Button buttonSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // TabControl
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPageData = new System.Windows.Forms.TabPage();
            tabPageRoadMap = new System.Windows.Forms.TabPage();
            dataGridViewRoadMap = new System.Windows.Forms.DataGridView();

            // Full Name
            labelFullName = new System.Windows.Forms.Label();
            textBoxFullName = new System.Windows.Forms.TextBox();

            // Entry Date controls
            labelEntryDate = new System.Windows.Forms.Label();
            dateTimePickerEntryDate = new System.Windows.Forms.DateTimePicker();

            // Registration Date
            labelRegistrationDate = new System.Windows.Forms.Label();
            dateTimePickerRegistrationDate = new System.Windows.Forms.DateTimePicker();

            // Patent Issue Date
            labelPatentIssueDate = new System.Windows.Forms.Label();
            dateTimePickerPatentIssueDate = new System.Windows.Forms.DateTimePicker();

            // Country
            labelCountry = new System.Windows.Forms.Label();
            comboBoxCountry = new System.Windows.Forms.ComboBox();

            // Checkboxes
            checkBoxQualification = new System.Windows.Forms.CheckBox();
            checkBoxIsInProgram = new System.Windows.Forms.CheckBox();
            checkBoxWasMigrant = new System.Windows.Forms.CheckBox();
            checkBoxHasWorkPermit = new System.Windows.Forms.CheckBox();
            checkBoxHasPatent = new System.Windows.Forms.CheckBox();

            // Entry Goal
            labelEntryGoal = new System.Windows.Forms.Label();
            comboBoxEntryGoal = new System.Windows.Forms.ComboBox();

            // Save button
            buttonSave = new System.Windows.Forms.Button();

            // 
            // tabControl1
            // 
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Controls.Add(tabPageData);
            tabControl1.Controls.Add(tabPageRoadMap);

            // 
            // tabPageData
            // 
            tabPageData.Text = "Данные";
            tabPageData.Padding = new System.Windows.Forms.Padding(10);
            tabPageData.AutoScroll = true;
            tabPageData.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                labelFullName, textBoxFullName,
                labelEntryDate, dateTimePickerEntryDate,
                labelRegistrationDate, dateTimePickerRegistrationDate,
                labelPatentIssueDate, dateTimePickerPatentIssueDate,
                labelCountry, comboBoxCountry,
                checkBoxQualification, checkBoxIsInProgram,
                checkBoxWasMigrant, checkBoxHasWorkPermit,
                checkBoxHasPatent,
                labelEntryGoal, comboBoxEntryGoal,
                buttonSave
            });

            // 
            // labelFullName
            // 
            labelFullName.AutoSize = true;
            labelFullName.Location = new System.Drawing.Point(20, 20);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new System.Drawing.Size(46, 20);
            labelFullName.Text = "ФИО";

            // 
            // textBoxFullName
            // 
            textBoxFullName.Location = new System.Drawing.Point(20, 50);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new System.Drawing.Size(300, 27);

            // 
            // labelEntryDate
            // 
            labelEntryDate.AutoSize = true;
            labelEntryDate.Location = new System.Drawing.Point(20, 100);
            labelEntryDate.Name = "labelEntryDate";
            labelEntryDate.Size = new System.Drawing.Size(93, 20);
            labelEntryDate.Text = "Дата въезда";

            // 
            // dateTimePickerEntryDate
            // 
            dateTimePickerEntryDate.Location = new System.Drawing.Point(20, 130);
            dateTimePickerEntryDate.Name = "dateTimePickerEntryDate";
            dateTimePickerEntryDate.Size = new System.Drawing.Size(200, 27);

            // 
            // labelRegistrationDate
            // 
            labelRegistrationDate.AutoSize = true;
            labelRegistrationDate.Location = new System.Drawing.Point(240, 100);
            labelRegistrationDate.Name = "labelRegistrationDate";
            labelRegistrationDate.Size = new System.Drawing.Size(134, 20);
            labelRegistrationDate.Text = "Дата регистрации";

            // 
            // dateTimePickerRegistrationDate
            // 
            dateTimePickerRegistrationDate.Location = new System.Drawing.Point(240, 130);
            dateTimePickerRegistrationDate.Name = "dateTimePickerRegistrationDate";
            dateTimePickerRegistrationDate.Size = new System.Drawing.Size(200, 27);

            // 
            // labelPatentIssueDate
            // 
            labelPatentIssueDate.AutoSize = true;
            labelPatentIssueDate.Location = new System.Drawing.Point(460, 100);
            labelPatentIssueDate.Name = "labelPatentIssueDate";
            labelPatentIssueDate.Size = new System.Drawing.Size(148, 20);
            labelPatentIssueDate.Text = "Дата выдачи патента";

            // 
            // dateTimePickerPatentIssueDate
            // 
            dateTimePickerPatentIssueDate.Location = new System.Drawing.Point(460, 130);
            dateTimePickerPatentIssueDate.Name = "dateTimePickerPatentIssueDate";
            dateTimePickerPatentIssueDate.Size = new System.Drawing.Size(200, 27);

            // 
            // labelCountry
            // 
            labelCountry.AutoSize = true;
            labelCountry.Location = new System.Drawing.Point(20, 180);
            labelCountry.Name = "labelCountry";
            labelCountry.Size = new System.Drawing.Size(58, 20);
            labelCountry.Text = "Страна";

            // 
            // comboBoxCountry
            // 
            comboBoxCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxCountry.Location = new System.Drawing.Point(20, 210);
            comboBoxCountry.Name = "comboBoxCountry";
            comboBoxCountry.Size = new System.Drawing.Size(200, 28);

            // 
            // checkBoxQualification
            // 
            checkBoxQualification.AutoSize = true;
            checkBoxQualification.Location = new System.Drawing.Point(20, 260);
            checkBoxQualification.Name = "checkBoxQualification";
            checkBoxQualification.Size = new System.Drawing.Size(182, 24);
            checkBoxQualification.Text = "Квалифицированный";

            // 
            // checkBoxIsInProgram
            // 
            checkBoxIsInProgram.AutoSize = true;
            checkBoxIsInProgram.Location = new System.Drawing.Point(20, 290);
            checkBoxIsInProgram.Name = "checkBoxIsInProgram";
            checkBoxIsInProgram.Size = new System.Drawing.Size(203, 24);
            checkBoxIsInProgram.Text = "Участник госпрограммы";

            // 
            // checkBoxWasMigrant
            // 
            checkBoxWasMigrant.AutoSize = true;
            checkBoxWasMigrant.Location = new System.Drawing.Point(20, 320);
            checkBoxWasMigrant.Name = "checkBoxWasMigrant";
            checkBoxWasMigrant.Size = new System.Drawing.Size(121, 24);
            checkBoxWasMigrant.Text = "Был на учете";

            // 
            // checkBoxHasWorkPermit
            // 
            checkBoxHasWorkPermit.AutoSize = true;
            checkBoxHasWorkPermit.Location = new System.Drawing.Point(20, 350);
            checkBoxHasWorkPermit.Name = "checkBoxHasWorkPermit";
            checkBoxHasWorkPermit.Size = new System.Drawing.Size(190, 24);
            checkBoxHasWorkPermit.Text = "Разрешение на работу";

            // 
            // checkBoxHasPatent
            // 
            checkBoxHasPatent.AutoSize = true;
            checkBoxHasPatent.Location = new System.Drawing.Point(20, 380);
            checkBoxHasPatent.Name = "checkBoxHasPatent";
            checkBoxHasPatent.Size = new System.Drawing.Size(79, 24);
            checkBoxHasPatent.Text = "Патент";

            // 
            // labelEntryGoal
            // 
            labelEntryGoal.AutoSize = true;
            labelEntryGoal.Location = new System.Drawing.Point(20, 420);
            labelEntryGoal.Name = "labelEntryGoal";
            labelEntryGoal.Size = new System.Drawing.Size(96, 20);
            labelEntryGoal.Text = "Цель въезда";

            // 
            // comboBoxEntryGoal
            // 
            comboBoxEntryGoal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxEntryGoal.Location = new System.Drawing.Point(20, 450);
            comboBoxEntryGoal.Name = "comboBoxEntryGoal";
            comboBoxEntryGoal.Size = new System.Drawing.Size(200, 28);

            // 
            // buttonSave
            // 
            buttonSave.Location = new System.Drawing.Point(20, 500);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new System.Drawing.Size(94, 29);
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += new System.EventHandler(this.buttonSave_Click);

            // 
            // tabPageRoadMap
            // 
            tabPageRoadMap.Text = "Дорожная карта";
            tabPageRoadMap.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewRoadMap.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridViewRoadMap.ReadOnly = true;
            dataGridViewRoadMap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            tabPageRoadMap.Controls.Add(dataGridViewRoadMap);

            // 
            // dataGridViewRoadMap
            // 
            dataGridViewRoadMap.Name = "dataGridViewRoadMap";
            dataGridViewRoadMap.Size = new System.Drawing.Size(660, 440);

            // 
            // UserInputForm
            // 
            this.Controls.Add(tabControl1);
            this.Text = "Панель мигранта";
            this.ClientSize = new System.Drawing.Size(700, 580);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }
    }
}

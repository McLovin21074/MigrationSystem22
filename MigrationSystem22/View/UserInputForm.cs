using System;
using System.Linq;
using System.Windows.Forms;
using MigrationSystem22.Controllers;

namespace MigrationSystem22.View
{
    public enum UserInputMode
    {
        Login,
        Register
    }

    public partial class UserInputForm : Form
    {
        private readonly UserController userController = new();
        private readonly int? userId;

        public UserInputForm(int? userId = null)
        {
            InitializeComponent();


            this.userId = userId;

            Load += UserInputForm_Load;
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            checkBoxWasMigrant.CheckedChanged += CheckBoxWasMigrant_CheckedChanged;
            checkBoxHasPatent.CheckedChanged += CheckBoxHasPatent_CheckedChanged;
        }

        private void UserInputForm_Load(object sender, EventArgs e)
        {
            comboBoxCountry.Items.AddRange(new[]
            {
                "Азербайджан","Армения","Беларусь","Казахстан","Киргизия",
                "Молдова","Россия","Таджикистан","Узбекистан", "Украина", "Другое"
            });
            comboBoxCountry.SelectedIndex = 0;

            comboBoxEntryGoal.Items.AddRange(new[]
            {
                "Трудовая деятельность","Учеба","Воссоединение семьи",
                "Гуманитарные цели","Туризм","Иное"
            });
            comboBoxEntryGoal.SelectedIndex = 0;

            if (userId.HasValue)
            {
                if (!userController.LoadUser(userId.Value, out var err))
                {
                    MessageBox.Show("Не удалось загрузить пользователя:\n" + err,
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                textBoxFullName.Text = userController.FullName;
                dateTimePickerEntryDate.Value = userController.EntryDate.ToLocalTime();

                checkBoxWasMigrant.Checked = userController.WasMigrant;
                dateTimePickerRegistrationDate.Enabled = userController.WasMigrant;
                if (userController.RegistrationDate.HasValue)
                    dateTimePickerRegistrationDate.Value = userController.RegistrationDate.Value.ToLocalTime();

                checkBoxHasPatent.Checked = userController.HasPatent;
                dateTimePickerPatentIssueDate.Enabled = userController.HasPatent;
                if (userController.PatentIssueDate.HasValue)
                    dateTimePickerPatentIssueDate.Value = userController.PatentIssueDate.Value.ToLocalTime();

                comboBoxCountry.SelectedItem = userController.Country;
                checkBoxQualification.Checked = userController.Qualification;
                checkBoxIsInProgram.Checked = userController.IsInProgram;
                checkBoxHasWorkPermit.Checked = userController.HasWorkPermit;
                comboBoxEntryGoal.SelectedItem = userController.EntryGoal;
            }
            else
            {
                userController.NewUser();
                checkBoxWasMigrant.Checked = false;
                checkBoxHasPatent.Checked = false;
                dateTimePickerRegistrationDate.Enabled = false;
                dateTimePickerPatentIssueDate.Enabled = false;
            }
        }

        private void CheckBoxWasMigrant_CheckedChanged(object? sender, EventArgs e)
        {
            dateTimePickerRegistrationDate.Enabled = checkBoxWasMigrant.Checked;
        }

        private void CheckBoxHasPatent_CheckedChanged(object? sender, EventArgs e)
        {
            dateTimePickerPatentIssueDate.Enabled = checkBoxHasPatent.Checked;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var entryDate = DateTime.SpecifyKind(
                dateTimePickerEntryDate.Value.Date,
                DateTimeKind.Utc
            );

            DateTime? registrationDate = checkBoxWasMigrant.Checked
                ? DateTime.SpecifyKind(
                    dateTimePickerRegistrationDate.Value.Date,
                    DateTimeKind.Utc
                  )
                : (DateTime?)null;

            DateTime? patentIssueDate = checkBoxHasPatent.Checked
                ? DateTime.SpecifyKind(
                    dateTimePickerPatentIssueDate.Value.Date,
                    DateTimeKind.Utc
                  )
                : (DateTime?)null;

            var fullName = textBoxFullName.Text.Trim();
            var country = comboBoxCountry.SelectedItem!.ToString();
            var qualification = checkBoxQualification.Checked;
            var isInProgram = checkBoxIsInProgram.Checked;
            var wasMigrant = checkBoxWasMigrant.Checked;
            var hasWorkPermit = checkBoxHasWorkPermit.Checked;
            var hasPatent = checkBoxHasPatent.Checked;
            var entryGoal = comboBoxEntryGoal.SelectedItem!.ToString();

            if (userController.EnterDetails(
                    entryDate,
                    registrationDate,
                    patentIssueDate,
                    fullName,
                    country,
                    qualification,
                    isInProgram,
                    wasMigrant,
                    hasWorkPermit,
                    hasPatent,
                    entryGoal,
                    out var err))
            {
                MessageBox.Show("Данные сохранены", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabControl1.SelectedTab = tabPageRoadMap;
            }
            else
            {
                MessageBox.Show("Ошибка при сохранении:\n" + err, "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPageRoadMap)
                LoadRoadMap();
        }

        private void LoadRoadMap()
        {
            var roadmap = userController.ViewRoadMap();

            var points = roadmap.Points
                .Select(p => new
                {
                    ЧтоПолучить = p.Text
                                  .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                  .FirstOrDefault() ?? "",
                    ЧтоСделать = p.Text.Contains("\n")
                                  ? p.Text[(p.Text.IndexOf('\n') + 1)..].Trim()
                                  : "",
                    КрайнийСрок = p.DeadlineDate
                                  .ToLocalTime()
                                  .ToString("dd.MM.yyyy")
                })
                .ToList();

            dataGridViewRoadMap.DataSource = points;
            FormatRoadMapGrid();
        }

        private void FormatRoadMapGrid()
        {
            var grid = dataGridViewRoadMap;

            grid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.Columns["ЧтоПолучить"].HeaderText = "Что нужно получить";
            grid.Columns["ЧтоСделать"].HeaderText = "Что нужно сделать";
            grid.Columns["КрайнийСрок"].HeaderText = "Крайний срок";

            grid.Columns["ЧтоПолучить"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
            grid.Columns["ЧтоСделать"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
            grid.Columns["КрайнийСрок"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grid.RowTemplate.DefaultCellStyle.Padding = new Padding(5);
            grid.RowHeadersVisible = false;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(grid.Font, System.Drawing.FontStyle.Bold);
        }
    }
}

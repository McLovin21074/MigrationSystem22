using MigrationSystem22.Controllers;
using MigrationSystem22.Models;

namespace MigrationSystem22.View;

public partial class UserInputForm : Form
{
    private readonly UserController _userController = new();

    public UserInputForm()
    {
        InitializeComponent();
        this.Load += UserInputForm_Load;
    }

    private void UserInputForm_Load(object sender, EventArgs e)
    {
        comboBoxCountry.Items.AddRange(new[]
        {
            "Азербайджан", "Армения", "Беларусь", "Казахстан", "Киргизия",
            "Молдова", "Россия", "Таджикистан", "Узбекистан", "Украина", "Другое"
        });

        comboBoxEntryGoal.Items.AddRange(new[]
        {
            "Трудовая деятельность",
            "Учеба",
            "Воссоединение семьи",
            "Гуманитарные цели",
            "Туризм",
            "Иное"
        });

        comboBoxCountry.SelectedIndex = 0;
        comboBoxEntryGoal.SelectedIndex = 0;
    }

    private void buttonSave_Click(object sender, EventArgs e)
    {
        var user = new User
        {
            EntryDate = DateTime.SpecifyKind(dateTimePickerEntryDate.Value.Date, DateTimeKind.Utc),
            Country = comboBoxCountry.SelectedItem?.ToString() ?? string.Empty,
            Qualification = checkBoxQualification.Checked,
            IsInProgram = checkBoxIsInProgram.Checked,
            WasMigrant = checkBoxWasMigrant.Checked,
            HasWorkPermit = checkBoxHasWorkPermit.Checked,
            HasPatent = checkBoxHasPatent.Checked,
            EntryGoal = comboBoxEntryGoal.SelectedItem?.ToString() ?? string.Empty
        };

        if (_userController.EnterDetails(user, out string error))
        {
            MessageBox.Show("Пользователь сохранён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        else
        {
            MessageBox.Show("Ошибка: " + error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
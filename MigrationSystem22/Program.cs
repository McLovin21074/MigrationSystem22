using MigrationSystem22.Data;
using MigrationSystem22.View;

namespace MigrationSystem22
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            try
            {
                using var db = new MigrationContext();

                var users = db.Users.ToList();

                if (users.Count == 0)
                {
                    MessageBox.Show("� ���� ��� �������������.");
                }
                else
                {
                    string msg = "������������ �� ��:\n";
                    foreach (var user in users)
                    {
                        msg += $"- {user.Country}, {user.EntryGoal}, {user.EntryDate.ToShortDateString()}\n";
                    }

                    MessageBox.Show(msg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("������ ��� ����������� � ��: " + ex.Message);
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new UserInputForm());

        }
    }
}
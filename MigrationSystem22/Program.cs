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
                    MessageBox.Show("В базе нет пользователей.");
                }
                else
                {
                    string msg = "Пользователи из БД:\n";
                    foreach (var user in users)
                    {
                        msg += $"- {user.Country}, {user.EntryGoal}, {user.EntryDate.ToShortDateString()}\n";
                    }

                    MessageBox.Show(msg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при подключении к БД: " + ex.Message);
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new UserInputForm());

        }
    }
}
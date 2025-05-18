using System;
using System.Windows.Forms;
using MigrationSystem22.View;

namespace MigrationSystem22
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Вместо RuleInputForm запускаем MainForm
            Application.Run(new MainForm());
        }
    }
}

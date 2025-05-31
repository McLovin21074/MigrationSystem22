using MigrationSystem22.Models;

namespace MigrationSystem22.Services
{
    public static class FieldDefinitionProvider
    {
        public static readonly Dictionary<string, FieldDefinition> Definitions
            = new()
            {
                ["Country"] = new FieldDefinition
                {
                    FieldType = typeof(string),
                    AllowedOperators = new[] { "=", "!="},
                    AllowedValues = null,
                    DisplayName = "Гражданство"
                },
                ["EntryGoal"] = new FieldDefinition
                {
                    FieldType = typeof(string),
                    AllowedOperators = new[] { "=", "!="},
                    AllowedValues = null,
                    DisplayName = "Цель въезда"
                },
                ["Qualification"] = new FieldDefinition
                {
                    FieldType = typeof(bool),
                    AllowedOperators = new[] { "=", "!=" },
                    AllowedValues = new[] { "True", "False" },
                    DisplayName = "Высококвалифицирован"
                },
                ["IsInProgram"] = new FieldDefinition
                {
                    FieldType = typeof(bool),
                    AllowedOperators = new[] { "=", "!=" },
                    AllowedValues = new[] { "True", "False" },
                    DisplayName = "Участие в гос. программе"
                },
                ["WasMigrant"] = new FieldDefinition
                {
                    FieldType = typeof(bool),
                    AllowedOperators = new[] { "=", "!=" },
                    AllowedValues = new[] { "True", "False" },
                    DisplayName = "Был на миграционном учете"
                },
                ["HasPatent"] = new FieldDefinition
                {
                    FieldType = typeof(bool),
                    AllowedOperators = new[] { "=", "!=" },
                    AllowedValues = new[] { "True", "False" },
                    DisplayName = "Есть ли патент"
                },
                ["HasWorkPermit"] = new FieldDefinition
                {
                    FieldType = typeof(bool),
                    AllowedOperators = new[] { "=", "!=" },
                    AllowedValues = new[] { "True", "False" },
                    DisplayName = "Есть ли разрешение на работу"
                }
            };
    }
}

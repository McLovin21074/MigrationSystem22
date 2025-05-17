using MigrationSystem22.Models;

namespace MigrationSystem22.Services
{
    public static class FieldDefinitionProvider
    {
        public static readonly Dictionary<string, FieldDefinition> Definitions
            = new()
            {
                ["EntryDate"] = new FieldDefinition
                {
                    FieldType = typeof(DateTime),
                    AllowedOperators = new[] { "=", "!=", ">", "<" },
                    AllowedValues = null
                },
                ["Country"] = new FieldDefinition
                {
                    FieldType = typeof(string),
                    AllowedOperators = new[] { "=", "!=", "IN", "NOT IN" },
                    AllowedValues = null
                },
                ["EntryGoal"] = new FieldDefinition
                {
                    FieldType = typeof(string),
                    AllowedOperators = new[] { "=", "!=", "IN", "NOT IN" },
                    AllowedValues = null
                },
                ["Qualification"] = new FieldDefinition
                {
                    FieldType = typeof(bool),
                    AllowedOperators = new[] { "=", "!=" },
                    AllowedValues = new[] { "True", "False" }
                },
                ["IsInProgram"] = new FieldDefinition
                {
                    FieldType = typeof(bool),
                    AllowedOperators = new[] { "=", "!=" },
                    AllowedValues = new[] { "True", "False" }
                },
                ["WasMigrant"] = new FieldDefinition
                {
                    FieldType = typeof(bool),
                    AllowedOperators = new[] { "=", "!=" },
                    AllowedValues = new[] { "True", "False" }
                },
                ["HasPatent"] = new FieldDefinition
                {
                    FieldType = typeof(bool),
                    AllowedOperators = new[] { "=", "!=" },
                    AllowedValues = new[] { "True", "False" }
                },
                ["HasWorkPermit"] = new FieldDefinition
                {
                    FieldType = typeof(bool),
                    AllowedOperators = new[] { "=", "!=" },
                    AllowedValues = new[] { "True", "False" }
                }
            };
    }
}

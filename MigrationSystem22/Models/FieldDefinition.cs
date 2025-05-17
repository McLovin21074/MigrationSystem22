using System;

namespace MigrationSystem22.Models
{
    public class FieldDefinition
    {
        public Type FieldType { get; set; }

        public string[] AllowedOperators { get; set; }

        public string[] AllowedValues { get; set; }
    }
}

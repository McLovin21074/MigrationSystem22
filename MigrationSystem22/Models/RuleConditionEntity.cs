namespace MigrationSystem22.Models
{
    public class RuleConditionEntity
    {
        public int ConditionId { get; set; }
        public int GroupId { get; set; }
        public ConditionGroupEntity Group { get; set; }

        public string FieldName { get; set; }
        public string Operator { get; set; }
        public string Value { get; set; }
    }
}

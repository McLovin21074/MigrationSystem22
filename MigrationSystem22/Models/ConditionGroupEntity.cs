namespace MigrationSystem22.Models
{
    public class ConditionGroupEntity
    {
        public int GroupId { get; set; }
        public int RuleId { get; set; }
        public RuleEntity Rule { get; set; }

        public List<RuleConditionEntity> Conditions { get; set; }
    }
}

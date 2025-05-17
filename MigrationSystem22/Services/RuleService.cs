using MigrationSystem22.Data;
using MigrationSystem22.Models;

namespace MigrationSystem22.Services;

public class RuleService
{
    public void SaveRule(string whatToGet, string instruction, ControlDateType deadlineEvent, int deadlineDays, List<RuleConditionEntity> conditions)
    {
        using var db = new MigrationContext();

        var rule = new RuleEntity
        {
            InstructionText = $"{whatToGet}\n\n{instruction}",
            DeadlineEvent = deadlineEvent,
            DeadlineDays = deadlineDays
        };

        db.Rules.Add(rule);
        db.SaveChanges();

        var group = new ConditionGroupEntity
        {
            RuleId = rule.RuleId
        };
        db.ConditionGroups.Add(group);
        db.SaveChanges();

        foreach (var cond in conditions)
        {
            cond.GroupId = group.GroupId;
            db.RuleConditions.Add(cond);
        }

        db.SaveChanges();
    }
}

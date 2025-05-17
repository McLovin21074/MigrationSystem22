using MigrationSystem22.Data;
using MigrationSystem22.Models;

namespace MigrationSystem22.Services
{
    public class RuleService
    {
        public void SaveDraft(RuleDraft draft)
        {
            using var db = new MigrationContext();

            var ruleEntity = new RuleEntity
            {
                InstructionText = $"{draft.WhatToGet}\n\n{draft.Instruction}",
                DeadlineEvent = draft.DeadlineEvent,
                DeadlineDays = draft.DeadlineDays
            };

            db.Rules.Add(ruleEntity);
            db.SaveChanges();

            foreach (var group in draft.Groups)
            {
                var groupEntity = new ConditionGroupEntity
                {
                    RuleId = ruleEntity.RuleId
                };
                db.ConditionGroups.Add(groupEntity);
                db.SaveChanges();

                foreach (var condition in group)
                {
                    condition.GroupId = groupEntity.GroupId;
                    db.RuleConditions.Add(condition);
                }
            }

            db.SaveChanges();
        }
    }
}

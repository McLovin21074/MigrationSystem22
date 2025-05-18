using System.Linq;
using Microsoft.EntityFrameworkCore;
using MigrationSystem22.Data;
using MigrationSystem22.Models;
using System.Collections.Generic;

namespace MigrationSystem22.Services
{
    public class RuleService
    {
        public void SaveDraft(RuleDraft draft)
        {
            using var db = new MigrationContext();

            var ruleEntity = new RuleEntity
            {
                WhatToGet = draft.WhatToGet,
                Instruction = draft.Instruction,
                DeadlineEvent = draft.DeadlineEvent,
                DeadlineDays = draft.DeadlineDays
            };
            db.Rules.Add(ruleEntity);
            db.SaveChanges();

            foreach (var group in draft.Groups)
            {
                var groupEntity = new ConditionGroupEntity { RuleId = ruleEntity.RuleId };
                db.ConditionGroups.Add(groupEntity);
                db.SaveChanges();

                foreach (var cond in group)
                {
                    cond.GroupId = groupEntity.GroupId;
                    db.RuleConditions.Add(cond);
                }
            }
            db.SaveChanges();
        }

        public RuleEntity GetRuleWithGroups(int ruleId)
        {
            using var db = new MigrationContext();
            return db.Rules
                     .Include(r => r.ConditionGroups)
                       .ThenInclude(g => g.Conditions)
                     .Single(r => r.RuleId == ruleId);
        }

        public void UpdateDraft(int ruleId, RuleDraft draft)
        {
            using var db = new MigrationContext();
            var rule = db.Rules
                         .Include(r => r.ConditionGroups)
                           .ThenInclude(g => g.Conditions)
                         .Single(r => r.RuleId == ruleId);

            rule.WhatToGet = draft.WhatToGet;
            rule.Instruction = draft.Instruction;
            rule.DeadlineEvent = draft.DeadlineEvent;
            rule.DeadlineDays = draft.DeadlineDays;

            var allOldConds = rule.ConditionGroups.SelectMany(g => g.Conditions).ToList();
            db.RuleConditions.RemoveRange(allOldConds);
            db.ConditionGroups.RemoveRange(rule.ConditionGroups);

            db.SaveChanges();

            foreach (var grp in draft.Groups)
            {
                var grpEnt = new ConditionGroupEntity { RuleId = ruleId };
                db.ConditionGroups.Add(grpEnt);
                db.SaveChanges();

                foreach (var cond in grp)
                {
                    cond.GroupId = grpEnt.GroupId;
                    db.RuleConditions.Add(cond);
                }
            }
            db.SaveChanges();
        }
        public List<RuleEntity> GetAllRules()
        {
            using var db = new MigrationContext();
            return db.Rules
                     .Include(r => r.ConditionGroups)
                       .ThenInclude(g => g.Conditions)
                     .ToList();
        }

        public void DeleteRule(int ruleId)
        {
            using var db = new MigrationContext();
            var stub = new RuleEntity { RuleId = ruleId };
            db.Rules.Attach(stub);
            db.Rules.Remove(stub);
            db.SaveChanges();
        }
    }
}

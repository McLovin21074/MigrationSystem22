using System;
using System.Collections.Generic;
using MigrationSystem22.Services;
using MigrationSystem22.Models;

namespace MigrationSystem22.Controllers
{
    public class RuleController
    {
        private readonly RuleService ruleService;
        private RuleDraft draft;

        public RuleController() : this(new RuleService()) { }
        public RuleController(RuleService ruleService) => this.ruleService = ruleService;

        public void AddRule() => draft = new RuleDraft();

        public void AddCondition(string fieldName, string @operator, string value)
        {
            if (draft == null) throw new InvalidOperationException("Сначала вызови AddRule()");
            draft.AddCondition(fieldName, @operator, value);
        }

        public void NewConditionGroup()
        {
            if (draft == null) throw new InvalidOperationException("Сначала вызови AddRule()");
            draft.StartNewGroup();
        }

        public void SetDeadline(ControlDateType deadlineEvent, int deadlineDays)
        {
            if (draft == null) throw new InvalidOperationException("Сначала вызови AddRule()");
            draft.DeadlineEvent = deadlineEvent;
            draft.DeadlineDays = deadlineDays;
        }

        public void Save()
        {
            if (draft == null) throw new InvalidOperationException("Сначала вызови AddRule()");
            ruleService.SaveDraft(draft);
            draft = null;
        }

        public void RemoveCondition(int groupIndex, int conditionIndex)
        {
            if (draft == null)
                throw new InvalidOperationException("Сначала вызови AddRule()");
            draft.RemoveCondition(groupIndex, conditionIndex);
        }

        public IReadOnlyList<List<RuleConditionEntity>> Groups => draft?.Groups;
    }
}

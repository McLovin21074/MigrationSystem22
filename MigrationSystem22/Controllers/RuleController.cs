using System;
using System.Collections.Generic;
using MigrationSystem22.Models;
using MigrationSystem22.Services;

namespace MigrationSystem22.Controllers
{
    public class RuleController
    {
        private readonly RuleService svc;
        private RuleDraft draft;
        private int? editingRuleId;

        public RuleController() : this(new RuleService()) { }
        public RuleController(RuleService svc) => this.svc = svc;

        public List<RuleEntity> GetAllRules() => svc.GetAllRules();
        public void DeleteRule(int id) => svc.DeleteRule(id);

        public void AddRule()
        {
            draft = new RuleDraft();
            editingRuleId = null;
        }

        public void LoadRule(int ruleId)
        {
            var entity = svc.GetRuleWithGroups(ruleId);
            draft = RuleDraft.FromEntity(entity);
            editingRuleId = ruleId;
        }

        public void AddCondition(string fieldName, string @operator, string value)
        {
            if (draft == null) throw new InvalidOperationException();
            draft.AddCondition(fieldName, @operator, value);
        }

        public void NewConditionGroup()
        {
            if (draft == null) throw new InvalidOperationException();
            draft.StartNewGroup();
        }

        public void RemoveCondition(int groupIndex, int conditionIndex)
        {
            if (draft == null) throw new InvalidOperationException();
            draft.RemoveCondition(groupIndex, conditionIndex);
        }

        public void SetCurrentConditionGroup(int index)
        {
            if (draft == null) throw new InvalidOperationException();
            draft.SetCurrentGroup(index);
        }

        public void SetMetadata(string whatToGet, string instruction)
        {
            if (draft == null) throw new InvalidOperationException();
            draft.WhatToGet = whatToGet;
            draft.Instruction = instruction;
        }

        public void SetDeadline(ControlDateType ev, int days)
        {
            if (draft == null) throw new InvalidOperationException();
            draft.DeadlineEvent = ev;
            draft.DeadlineDays = days;
        }

        public void Save()
        {
            if (draft == null) throw new InvalidOperationException();
            if (editingRuleId.HasValue)
                svc.UpdateDraft(editingRuleId.Value, draft);
            else
                svc.SaveDraft(draft);
        }

        public IReadOnlyList<List<RuleConditionEntity>> Groups => draft?.Groups;
        public IEnumerable<string> AvailableFields => FieldDefinitionProvider.Definitions.Keys;
        public FieldDefinition GetFieldDefinition(string f) => FieldDefinitionProvider.Definitions[f];

        public string DraftWhatToGet => draft?.WhatToGet ?? string.Empty;
        public string DraftInstruction => draft?.Instruction ?? string.Empty;
        public ControlDateType DraftDeadlineEvent => draft?.DeadlineEvent ?? default;
        public int DraftDeadlineDays => draft?.DeadlineDays ?? 0;
    }
}

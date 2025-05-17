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

        public IEnumerable<string> AvailableFields
    => FieldDefinitionProvider.Definitions.Keys;

        public FieldDefinition GetFieldDefinition(string fieldName)
            => FieldDefinitionProvider.Definitions[fieldName];

        public void AddRule() => draft = new RuleDraft();

        public void AddCondition(string fieldName, string @operator, string value)
        {
            if (draft == null)
                throw new InvalidOperationException("Сначала вызови AddRule()");
            draft.AddCondition(fieldName, @operator, value);
        }

        public void NewConditionGroup()
        {
            if (draft == null)
                throw new InvalidOperationException("Сначала вызови AddRule()");
            draft.StartNewGroup();
        }

        public void SetDeadline(ControlDateType ev, int days)
        {
            if (draft == null)
                throw new InvalidOperationException("Сначала вызови AddRule()");
            draft.DeadlineEvent = ev;
            draft.DeadlineDays = days;
        }

        public void Save()
        {
            if (draft == null)
                throw new InvalidOperationException("Сначала вызови AddRule()");
            ruleService.SaveDraft(draft);
            draft = null;
        }

        public void RemoveCondition(int groupIndex, int conditionIndex)
        {
            if (draft == null)
                throw new InvalidOperationException("Сначала вызови AddRule()");
            draft.RemoveCondition(groupIndex, conditionIndex);
        }

        public void SetMetadata(string whatToGet, string instruction)
        {
            if (draft == null) throw new InvalidOperationException("Сначала AddRule()");
            draft.WhatToGet = whatToGet;
            draft.Instruction = instruction;
        }


        public IReadOnlyList<List<RuleConditionEntity>> Groups => draft?.Groups;
    }
}

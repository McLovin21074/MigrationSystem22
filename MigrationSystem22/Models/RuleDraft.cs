using System;
using System.Collections.Generic;

namespace MigrationSystem22.Models
{
    public class RuleDraft
    {
        public string WhatToGet { get; set; }
        public string Instruction { get; set; }
        public ControlDateType DeadlineEvent { get; set; }
        public int DeadlineDays { get; set; }

        private readonly List<List<RuleConditionEntity>> groups = new();
        private int currentGroupIndex;

        public IReadOnlyList<List<RuleConditionEntity>> Groups => groups;

        public RuleDraft()
        {
            StartNewGroup();
        }

        public void StartNewGroup()
        {
            groups.Add(new List<RuleConditionEntity>());
            currentGroupIndex = groups.Count - 1;
        }

        public void SetCurrentGroup(int index)
        {
            if (index < 0 || index >= groups.Count)
                throw new ArgumentOutOfRangeException(nameof(index));
            currentGroupIndex = index;
        }

        public void AddCondition(string fieldName, string @operator, string value)
        {
            if (currentGroupIndex < 0)
                throw new InvalidOperationException("Нет активной группы");
            var cond = new RuleConditionEntity
            {
                FieldName = fieldName,
                Operator = @operator,
                Value = value
            };
            groups[currentGroupIndex].Add(cond);
        }

        public void RemoveCondition(int groupIndex, int conditionIndex)
        {
            if (groupIndex < 0 || groupIndex >= groups.Count)
                throw new ArgumentOutOfRangeException(nameof(groupIndex));
            var group = groups[groupIndex];
            if (conditionIndex < 0 || conditionIndex >= group.Count)
                throw new ArgumentOutOfRangeException(nameof(conditionIndex));
            group.RemoveAt(conditionIndex);
        }

        public static RuleDraft FromEntity(RuleEntity e)
        {
            var d = new RuleDraft
            {
                WhatToGet = e.WhatToGet,
                Instruction = e.Instruction,
                DeadlineEvent = e.DeadlineEvent,
                DeadlineDays = e.DeadlineDays
            };
            d.groups.Clear();
            foreach (var g in e.ConditionGroups)
            {
                d.StartNewGroup();
                foreach (var c in g.Conditions)
                    d.AddCondition(c.FieldName, c.Operator, c.Value);
            }
            return d;
        }
    }
}

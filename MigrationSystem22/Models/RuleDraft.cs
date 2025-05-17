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

        public void AddCondition(string fieldName, string @operator, string value)
        {
            if (currentGroupIndex < 0)
                throw new InvalidOperationException("Группа условий не инициализирована");

            var condition = new RuleConditionEntity
            {
                FieldName = fieldName,
                Operator = @operator,
                Value = value
            };
            groups[currentGroupIndex].Add(condition);
        }

        public void LoadGroups(List<List<RuleConditionEntity>> externalGroups)
        {
            groups.Clear();
            foreach (var grp in externalGroups)
            {
                var newGrp = new List<RuleConditionEntity>();
                foreach (var cond in grp)
                    newGrp.Add(new RuleConditionEntity
                    {
                        FieldName = cond.FieldName,
                        Operator = cond.Operator,
                        Value = cond.Value
                    });
                groups.Add(newGrp);
            }
            currentGroupIndex = 0;
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
    }
}

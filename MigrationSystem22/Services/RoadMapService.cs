using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MigrationSystem22.Data;
using MigrationSystem22.Models;
using Microsoft.EntityFrameworkCore;

namespace MigrationSystem22.Services
{
    public class RoadMapService
    {
        private readonly MigrationContext db = new();

        public RoadMap GenerateForUser(User user)
        {
            var roadmap = new RoadMap { User = user, Points = new List<RoadMapPoint>() };

            // 1) Загружаем все правила вместе с группами и условиями
            var rules = db.Rules
                          .Include(r => r.ConditionGroups)
                            .ThenInclude(g => g.Conditions)
                          .ToList();

            foreach (var rule in rules)
            {
                if (IsRuleApplicable(rule, user))
                {
                    // 2) Вычисляем дату дедлайна
                    DateTime start = rule.DeadlineEvent switch
                    {
                        ControlDateType.entry_date => user.EntryDate,
                        ControlDateType.registration_date => user.RegistrationDate,
                        ControlDateType.patent_issue_date => user.PatentIssueDate,
                        _ => user.EntryDate
                    };
                    var deadline = start.AddDays(rule.DeadlineDays);

                    // 3) Формируем пункт дорожной карты
                    roadmap.Points.Add(new RoadMapPoint
                    {
                        RuleId = rule.RuleId,
                        UserId = user.Id,
                        Text = $"{rule.WhatToGet}\n\n{rule.Instruction}",
                        DeadlineDate = deadline
                    });
                }
            }

            return roadmap;
        }

        private bool IsRuleApplicable(RuleEntity rule, User user)
        {
            // Для каждой группы (И between groups) проверяем, что в ней хотя бы одно условие истинно (ИЛИ внутри группы)
            return rule.ConditionGroups
                       .All(group => group.Conditions
                                           .Any(cond => EvaluateCondition(cond, user)));
        }

        private bool EvaluateCondition(RuleConditionEntity cond, User user)
        {
            // 1) Получаем свойство пользователя по имени
            var prop = typeof(User).GetProperty(cond.FieldName, BindingFlags.Public | BindingFlags.Instance);
            var userVal = prop.GetValue(user);

            // 2) Преобразуем строку cond.Value к тому же типу
            var targetVal = Convert.ChangeType(cond.Value, prop.PropertyType);

            // 3) Сравниваем в зависимости от оператора
            return cond.Operator switch
            {
                "=" => userVal.Equals(targetVal),
                "!=" => !userVal.Equals(targetVal),
                "IN" => ((IEnumerable<string>)targetVal).Contains(userVal.ToString()),
                "NOT IN" => !((IEnumerable<string>)targetVal).Contains(userVal.ToString()),
                _ => false
            };
        }
    }
}

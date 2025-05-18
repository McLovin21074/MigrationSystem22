using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MigrationSystem22.Data;
using MigrationSystem22.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace MigrationSystem22.Services
{
    public class RoadMapService
    {
        private readonly MigrationContext db = new();

        public RoadMap GenerateForUser(User user)
        {
            var roadmap = new RoadMap { User = user, Points = new List<RoadMapPoint>() };

            var rules = db.Rules
                          .Include(r => r.ConditionGroups)
                            .ThenInclude(g => g.Conditions)
                          .ToList();

            foreach (var rule in rules)
            {
                if (!IsRuleApplicable(rule, user))
                    continue;

                DateTime start = rule.DeadlineEvent switch
                {
                    ControlDateType.entry_date => user.EntryDate,
                    ControlDateType.registration_date => user.RegistrationDate ?? user.EntryDate,
                    ControlDateType.patent_issue_date => user.PatentIssueDate ?? user.EntryDate,
                    _ => user.EntryDate
                };

                var deadline = start.AddDays(rule.DeadlineDays);

                roadmap.Points.Add(new RoadMapPoint
                {
                    RuleId = rule.RuleId,
                    UserId = user.Id,
                    Text = $"{rule.WhatToGet}\n\n{rule.Instruction}",
                    DeadlineDate = deadline
                });
            }

            return roadmap;
        }


        private bool IsRuleApplicable(RuleEntity rule, User user)
        {
            var nonEmptyGroups = rule.ConditionGroups
                                     .Where(g => g.Conditions.Count > 0);

            if (!nonEmptyGroups.Any())
                return false;

            return nonEmptyGroups
                     .All(gr => gr.Conditions.Any(cond => EvaluateCondition(cond, user)));
        }

        private bool EvaluateCondition(RuleConditionEntity cond, User user)
        {
            var prop = typeof(User).GetProperty(cond.FieldName,
                                                BindingFlags.Public | BindingFlags.Instance);
            var userValObj = prop.GetValue(user);
            var targetType = Nullable.GetUnderlyingType(prop.PropertyType)
                             ?? prop.PropertyType;

            if (targetType == typeof(DateTime))
            {
                if (!DateTime.TryParseExact(cond.Value,
                                            "dd.MM.yyyy",
                                            CultureInfo.InvariantCulture,
                                            DateTimeStyles.None,
                                            out var condDate))
                    return false;

                var userDate = ((DateTime)userValObj).Date;
                switch (cond.Operator)
                {
                    case "=": return userDate == condDate;
                    case "!=": return userDate != condDate;
                    case ">": return userDate > condDate;
                    case "<": return userDate < condDate;
                    default: return false;
                }
            }

            if (targetType == typeof(bool))
            {
                if (!bool.TryParse(cond.Value, out var condBool))
                    return false;
                var userBool = (bool)userValObj;
                return cond.Operator switch
                {
                    "=" => userBool == condBool,
                    "!=" => userBool != condBool,
                    _ => false
                };
            }

            var condValTyped = Convert.ChangeType(cond.Value, targetType);
            return cond.Operator switch
            {
                "=" => userValObj.Equals(condValTyped),
                "!=" => !userValObj.Equals(condValTyped),
                _ => false
            };
        }

    }
}

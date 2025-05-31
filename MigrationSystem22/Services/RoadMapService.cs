using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MigrationSystem22.Data;
using MigrationSystem22.Models;

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

            roadmap.Points = roadmap.Points
                .GroupBy(p => p.Text)
                .Select(g => g.OrderBy(p => p.DeadlineDate).First())
                .OrderBy(p => p.DeadlineDate)
                .ToList();

            return roadmap;
        }

        private bool IsRuleApplicable(RuleEntity rule, User user)
        {
            var nonEmptyGroups = rule.ConditionGroups
                                     .Where(g => g.Conditions.Count > 0);

            if (nonEmptyGroups.Count() == 0)
                return false;

            return nonEmptyGroups
                     .All(gr => gr.Conditions.Any(cond => EvaluateCondition(cond, user)));
        }

        private bool EvaluateCondition(RuleConditionEntity cond, User user)
        {
            var prop = typeof(User).GetProperty(cond.FieldName,
                                                System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
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
                return cond.Operator switch
                {
                    "=" => userDate == condDate,
                    "!=" => userDate != condDate,
                    ">" => userDate > condDate,
                    "<" => userDate < condDate,
                    _ => false
                };
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

            if (targetType == typeof(int)
                || targetType == typeof(double)
                || targetType == typeof(decimal)
                || targetType == typeof(float)
                || targetType == typeof(long)
                || targetType == typeof(short))
            {
                try
                {
                    var userNum = Convert.ToDecimal(userValObj, CultureInfo.InvariantCulture);
                    var condNum = Convert.ToDecimal(cond.Value, CultureInfo.InvariantCulture);
                    return cond.Operator switch
                    {
                        "=" => userNum == condNum,
                        "!=" => userNum != condNum,
                        ">" => userNum > condNum,
                        "<" => userNum < condNum,
                        ">=" => userNum >= condNum,
                        "<=" => userNum <= condNum,
                        _ => false
                    };
                }
                catch
                {
                    return false;
                }
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

using MigrationSystem22.Models;
using MigrationSystem22.Services;

namespace MigrationSystem22.Controllers;

public class RuleController
{
    private readonly RuleService _ruleService = new();

    public void SaveRule(string whatToGet, string instruction, ControlDateType deadlineEvent, int deadlineDays, List<RuleConditionEntity> conditions)
    {
        _ruleService.SaveRule(whatToGet, instruction, deadlineEvent, deadlineDays, conditions);
    }
}

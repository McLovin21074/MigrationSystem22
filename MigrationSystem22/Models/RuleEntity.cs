using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationSystem22.Models
{
    public class RuleEntity
    {
        public int RuleId { get; set; }
        public string InstructionText { get; set; }
        public string DeadlineEvent { get; set; }
        public int DeadlineDays { get; set; }

        public List<ConditionGroupEntity> ConditionGroups { get; set; }
    }
}

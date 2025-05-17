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

        public string WhatToGet { get; set; }
        public string Instruction { get; set; }

        public ControlDateType DeadlineEvent { get; set; }
        public int DeadlineDays { get; set; }

        public List<ConditionGroupEntity> ConditionGroups { get; set; }
    }


    public enum ControlDateType
    {
        entry_date,
        registration_date,
        patent_issue_date
    }

}

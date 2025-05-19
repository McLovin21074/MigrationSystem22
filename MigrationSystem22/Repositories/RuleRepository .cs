using MigrationSystem22.Data;
using MigrationSystem22.Models;
using Microsoft.EntityFrameworkCore;


namespace MigrationSystem22.Repositories
{
    public class RuleRepository : IRuleRepository
    {
        private readonly MigrationContext _db;
        public RuleRepository(MigrationContext db) => _db = db;

        public RuleEntity GetWithGroups(int ruleId) =>
          _db.Rules
             .Include(r => r.ConditionGroups)
               .ThenInclude(g => g.Conditions)
             .Single(r => r.RuleId == ruleId);

        public void Add(RuleEntity rule) =>
          _db.Rules.Add(rule);

        public void Remove(RuleEntity rule) =>
          _db.Rules.Remove(rule);

        public IQueryable<RuleEntity> ListAll() =>
          _db.Rules
             .Include(r => r.ConditionGroups)
               .ThenInclude(g => g.Conditions);

        public void SaveChanges() =>
          _db.SaveChanges();
    }
}

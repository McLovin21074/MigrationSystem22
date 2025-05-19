using MigrationSystem22.Models;


namespace MigrationSystem22.Repositories
{
    public interface IRuleRepository
    {
        RuleEntity GetWithGroups(int ruleId);
        void Add(RuleEntity rule);
        void Remove(RuleEntity rule);
        IQueryable<RuleEntity> ListAll();
        void SaveChanges();
    }
}

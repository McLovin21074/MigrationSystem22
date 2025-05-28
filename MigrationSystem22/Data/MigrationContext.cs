using Microsoft.EntityFrameworkCore;
using MigrationSystem22.Models;
namespace MigrationSystem22.Data
{
    public class MigrationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<RuleEntity> Rules { get; set; }
        public DbSet<ConditionGroupEntity> ConditionGroups { get; set; }
        public DbSet<RuleConditionEntity> RuleConditions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql("Host=localhost;Database=MigrationSystem1;Username=postgres;Password=toor", o =>
            {
                o.MapEnum<ControlDateType>();
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum<ControlDateType>();

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.FullName).HasColumnName("full_name");
                entity.Property(e => e.EntryDate).HasColumnName("entry_date");
                entity.Property(e => e.RegistrationDate).HasColumnName("registration_date");
                entity.Property(e => e.PatentIssueDate).HasColumnName("patent_issue_date");
                entity.Property(e => e.Country).HasColumnName("country");
                entity.Property(e => e.Qualification).HasColumnName("qualification");
                entity.Property(e => e.IsInProgram).HasColumnName("is_in_program");
                entity.Property(e => e.WasMigrant).HasColumnName("was_migrant");
                entity.Property(e => e.HasPatent).HasColumnName("has_patent");
                entity.Property(e => e.HasWorkPermit).HasColumnName("has_work_permit");
                entity.Property(e => e.EntryGoal).HasColumnName("entry_goal");
            });

            modelBuilder.Entity<RuleEntity>(entity =>
            {
                entity.ToTable("rules");
                entity.HasKey(e => e.RuleId);
                entity.Property(e => e.RuleId).HasColumnName("rule_id");

                entity.Property(e => e.WhatToGet)
                      .HasColumnName("what_to_get")
                      .IsRequired();

                entity.Property(e => e.Instruction)
                      .HasColumnName("instruction")
                      .IsRequired();

                entity.Property(e => e.DeadlineEvent).HasColumnName("deadline_event");
                entity.Property(e => e.DeadlineDays).HasColumnName("deadline_days");

                entity.HasMany(r => r.ConditionGroups)
                      .WithOne(g => g.Rule)
                      .HasForeignKey(g => g.RuleId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ConditionGroupEntity>(entity =>
            {
                entity.ToTable("conditiongroups");
                entity.HasKey(e => e.GroupId);
                entity.Property(e => e.GroupId).HasColumnName("group_id");
                entity.Property(e => e.RuleId).HasColumnName("rule_id");

                entity.HasMany(g => g.Conditions)
                      .WithOne(c => c.Group)
                      .HasForeignKey(c => c.GroupId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<RuleConditionEntity>(entity =>
            {
                entity.ToTable("ruleconditions");
                entity.HasKey(e => e.ConditionId);
                entity.Property(e => e.ConditionId).HasColumnName("condition_id");
                entity.Property(e => e.GroupId).HasColumnName("group_id");
                entity.Property(e => e.FieldName).HasColumnName("field_name");
                entity.Property(e => e.Operator).HasColumnName("operator");
                entity.Property(e => e.Value).HasColumnName("value");
            });
        }
    }
}

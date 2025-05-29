using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MigrationSystem22.Data;
using MigrationSystem22.Models;
using BCrypt.Net;

namespace MigrationSystem22.Services
{
    public class AccountService
    {

        public bool HasAnyOperator()
        {
            using var db = new MigrationContext();
            return db.Accounts.Any(a => a.Role == "Operator");
        }


        public AccountEntity RegisterOperatorOrMigrant(string username, string password, string role)
        {
            using var db = new MigrationContext();

            if (db.Accounts.Any(a => a.Username == username))
                throw new InvalidOperationException("Логин занят");

            var user = new User
            {
                FullName = username,
                EntryDate = DateTime.UtcNow,
                Country = "Не указано",
                EntryGoal = "Не указано",
                Qualification = false,
                IsInProgram = false,
                WasMigrant = false,
                HasWorkPermit = false,
                HasPatent = false
            };
            db.Users.Add(user);
            db.SaveChanges();

            var acct = new AccountEntity
            {
                UserId = user.Id,
                Username = username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                Role = role
            };
            db.Accounts.Add(acct);
            db.SaveChanges();

            acct.User = user;
            return acct;
        }

        public AccountEntity AuthenticateAccount(string username, string password)
        {
            using var db = new MigrationContext();
            var acct = db.Accounts
                         .Include(a => a.User)
                         .SingleOrDefault(a => a.Username == username);

            if (acct == null || !BCrypt.Net.BCrypt.Verify(password, acct.PasswordHash))
                return null;

            return acct;
        }
    }
}

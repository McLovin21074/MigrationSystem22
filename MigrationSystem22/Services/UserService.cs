using MigrationSystem22.Data;
using MigrationSystem22.Models;

namespace MigrationSystem22.Services
{
    public class UserService
    {
        public void SaveUser(User user)
        {
            using var db = new MigrationContext();
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            using var db = new MigrationContext();
            db.Users.Update(user);
            db.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            using var db = new MigrationContext();
            return db.Users.ToList();
        }

        public User GetUserById(int id)
        {
            using var db = new MigrationContext();
            return db.Users.Find(id);
        }
    }
}

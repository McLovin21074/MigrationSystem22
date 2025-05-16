using MigrationSystem22.Data;
using MigrationSystem22.Models;

namespace MigrationSystem22.Services;

public class UserService
{
    public void SaveUser(User user)
    {
        using var db = new MigrationContext();
        db.Users.Add(user);
        db.SaveChanges();
    }
}
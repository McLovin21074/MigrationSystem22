namespace MigrationSystem22.Models
{
    public class AccountEntity
    {
        public int AccountId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
    }
}

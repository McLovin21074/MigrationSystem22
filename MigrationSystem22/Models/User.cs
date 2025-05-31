namespace MigrationSystem22.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }  
        public DateTime EntryDate { get; set; }
        public DateTime? RegistrationDate { get; set; } 
        public DateTime? PatentIssueDate { get; set; }
        public string Country { get; set; }
        public bool Qualification { get; set; }
        public bool IsInProgram { get; set; }
        public bool WasMigrant { get; set; }
        public bool HasPatent { get; set; }
        public bool HasWorkPermit { get; set; }
        public string EntryGoal { get; set; }
    }
}


namespace MigrationSystem22.Models
{
    public class RoadMapPoint
    {
        public int RuleId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public DateTime DeadlineDate { get; set; }
    }
}
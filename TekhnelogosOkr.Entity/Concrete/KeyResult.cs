using TekhnelogosOkr.Core.Entities.Concrete;

namespace TekhnelogosOkr.Entity.Concrete
{
    public class KeyResult : BaseEntity
    {
        public string Title { get; set; }
        public int OwnerId { get; set; }
        public int OkrObjectiveId { get; set; }
        public DateTime TargetDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int? Progress { get; set; }
        public User Owner { get; set; }
        public OkrObjective OkrObjective { get; set; }

        public ICollection<KeyResultOkrObjective> KeyResultOkrObjectives { get; set; }
        public ICollection<KeyResultTransaction> KeyResultTransactions { get; set; }
    }
}
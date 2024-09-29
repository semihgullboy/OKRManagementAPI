using TekhnelogosOkr.Core.Entities.Concrete;

namespace TekhnelogosOkr.Entity.Concrete
{
    public class OkrObjectiveTransaction : BaseEntity
    {
        public int OkrObjectiveId { get; set; }
        public OkrObjective Objective { get; set; }
        public string Content { get; set; }
        public int UpdatedByUserId { get; set; }
        public User UpdatedByUser { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}

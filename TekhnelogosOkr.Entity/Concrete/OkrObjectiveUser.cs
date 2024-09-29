using TekhnelogosOkr.Core.Entities.Concrete;

namespace TekhnelogosOkr.Entity.Concrete
{
    public class OkrObjectiveUser : BaseEntity
    {
        public int OkrObjectiveId { get; set; }
        public OkrObjective Objective { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }
    }
}

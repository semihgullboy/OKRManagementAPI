using TekhnelogosOkr.Core.Entities.Concrete;

namespace TekhnelogosOkr.Entity.Concrete
{
    public class KeyResultOkrObjective :BaseEntity
    {
        public int? KeyResultId { get; set; }
        public KeyResult KeyResult { get; set; }

        public int ObjectiveId { get; set; }
        public OkrObjective Objective { get; set; }
    }
}

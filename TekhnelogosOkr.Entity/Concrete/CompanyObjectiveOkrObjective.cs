using TekhnelogosOkr.Core.Entities.Concrete;

namespace TekhnelogosOkr.Entity.Concrete
{
    public class CompanyObjectiveOkrObjective : BaseEntity
    {
        public int CompanyObjectiveId { get; set; }
        public CompanyObjective CompanyObjective { get; set; }

        public int ObjectiveId { get; set; }
        public OkrObjective Objective { get; set; }
    }
}

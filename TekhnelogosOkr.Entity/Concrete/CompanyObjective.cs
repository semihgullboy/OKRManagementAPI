using TekhnelogosOkr.Common.Enum;
using TekhnelogosOkr.Core.Entities.Concrete;

namespace TekhnelogosOkr.Entity.Concrete
{
    public class CompanyObjective : BaseEntity
    {
        public string Title { get; set; } 
        public int Weight { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int? Progress { get; set; }

        public int? StatusId { get; set; } = (int)OkrStatus.DevamEdiyor;
        public Status Status { get; set; }

        public ICollection<CompanyObjectiveOkrObjective> CompanyObjectiveOkrObjectives { get; set; }
    }
}

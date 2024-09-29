using TekhnelogosOkr.Common.Enum;
using TekhnelogosOkr.Core.Entities.Concrete;

namespace TekhnelogosOkr.Entity.Concrete
{
    public class OkrObjective : BaseEntity
    {
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int Weight { get; set; }
        public int? Progress { get; set; }
        public int? StatusId { get; set; } = (int)OkrStatus.DevamEdiyor;
        public Status Status { get; set; }

        public ICollection<CompanyObjectiveOkrObjective> CompanyObjectiveOkrObjectives { get; set; }
        public ICollection<OkrObjectiveUser> OkrObjectiveUsers { get; set; }
        public ICollection<KeyResult> KeyResults { get; set; }
        public ICollection<OkrObjectiveTransaction> OkrObjectiveTransactions { get; set; }
    }
}

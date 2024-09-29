using TekhnelogosOkr.Core.Entities.Concrete;

namespace TekhnelogosOkr.Entity.Concrete
{
    public class Status : BaseEntity
    {
        public string StatusName { get; set; }

        public ICollection<CompanyObjective> CompanyObjectives { get; set; }
    }
}

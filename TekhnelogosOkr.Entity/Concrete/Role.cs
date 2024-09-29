using TekhnelogosOkr.Core.Entities.Concrete;
using TekhnelogosOkr.Entity.Concrete.TekhnelogosOkr.Entity.Concrete;

namespace TekhnelogosOkr.Entity.Concrete
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}


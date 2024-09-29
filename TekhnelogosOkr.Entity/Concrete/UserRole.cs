using TekhnelogosOkr.Core.Entities.Concrete;

namespace TekhnelogosOkr.Entity.Concrete
{
    namespace TekhnelogosOkr.Entity.Concrete
    {
        public class UserRole : BaseEntity
        {
            public int UserId { get; set; }
            public User User { get; set; }
            public int RoleId { get; set; }
            public Role Role { get; set; }
        }
    }
}

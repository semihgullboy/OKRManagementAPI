using TekhnelogosOkr.Core.Entities.Concrete;
using TekhnelogosOkr.Entity.Concrete.TekhnelogosOkr.Entity.Concrete;

namespace TekhnelogosOkr.Entity.Concrete
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? StartWorkDate { get; set; }
        public int? DepartmentID { get; set; }
        public int? ManagerID { get; set; }
        public string EmailAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
        public Department Departments { get; set; }
        public User Manager { get; set; }
        public ICollection<OkrObjectiveUser> OkrObjectiveUsers { get; set; }
    }
}

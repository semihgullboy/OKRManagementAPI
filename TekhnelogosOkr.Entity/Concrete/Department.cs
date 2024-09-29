using TekhnelogosOkr.Core.Entities.Concrete;

namespace TekhnelogosOkr.Entity.Concrete
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public int? DepartmentManagerID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public ICollection<User> Users { get; set; }
    }
}

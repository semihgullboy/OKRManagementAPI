using TekhnelogosOkr.Core.DataAccess.Concrete.EntityFramework;
using TekhnelogosOkr.DataAccess.Abstract;
using TekhnelogosOkr.DataAccess.Concrete.Context;
using TekhnelogosOkr.Entity.Concrete;

namespace TekhnelogosOkr.DataAccess.Concrete.EntityFramework
{
    public class EfDepartmentDal : EfEntityRepositoryBase<Department, TekhnelogosOkrContext>, IDepartmentDal
    {
        public EfDepartmentDal(TekhnelogosOkrContext context) : base(context)
        {
        }
    }
}
using TekhnelogosOkr.Core.DataAccess.Concrete.EntityFramework;
using TekhnelogosOkr.DataAccess.Abstract;
using TekhnelogosOkr.DataAccess.Concrete.Context;
using TekhnelogosOkr.Entity.Concrete.TekhnelogosOkr.Entity.Concrete;

namespace TekhnelogosOkr.DataAccess.Concrete.EntityFramework
{
    public class EfUserRoleDal : EfEntityRepositoryBase<UserRole, TekhnelogosOkrContext>, IUserRoleDal
    {
        public EfUserRoleDal(TekhnelogosOkrContext context) : base(context)
        {
        }
    }
}

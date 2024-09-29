using TekhnelogosOkr.Core.DataAccess.Concrete.EntityFramework;
using TekhnelogosOkr.DataAccess.Abstract;
using TekhnelogosOkr.DataAccess.Concrete.Context;
using TekhnelogosOkr.Entity.Concrete;

namespace TekhnelogosOkr.DataAccess.Concrete.EntityFramework
{
    public class EfStatusDal : EfEntityRepositoryBase<Status, TekhnelogosOkrContext>, IStatusDal
    {
        public EfStatusDal(TekhnelogosOkrContext context) : base(context)
        {
        }
    }
}
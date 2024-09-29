using TekhnelogosOkr.Core.DataAccess.Concrete.EntityFramework;
using TekhnelogosOkr.DataAccess.Abstract;
using TekhnelogosOkr.DataAccess.Concrete.Context;
using TekhnelogosOkr.Entity.Concrete;

namespace TekhnelogosOkr.DataAccess.Concrete.EntityFramework
{
    public class EfOkrObjectiveUserDal : EfEntityRepositoryBase<OkrObjectiveUser, TekhnelogosOkrContext>, IOkrObjectiveUserDal
    {
        public EfOkrObjectiveUserDal(TekhnelogosOkrContext context) : base(context)
        {
        }
    }
}
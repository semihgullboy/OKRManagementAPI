using TekhnelogosOkr.Core.DataAccess.Concrete.EntityFramework;
using TekhnelogosOkr.DataAccess.Abstract;
using TekhnelogosOkr.DataAccess.Concrete.Context;
using TekhnelogosOkr.Entity.Concrete;

namespace TekhnelogosOkr.DataAccess.Concrete.EntityFramework
{
    public class EfKeyResult : EfEntityRepositoryBase<KeyResult, TekhnelogosOkrContext>, IKeyResultDal
    {
        public EfKeyResult(TekhnelogosOkrContext context) : base(context)
        {
        }
    }
}
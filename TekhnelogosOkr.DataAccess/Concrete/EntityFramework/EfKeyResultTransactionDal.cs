using TekhnelogosOkr.Core.DataAccess.Concrete.EntityFramework;
using TekhnelogosOkr.DataAccess.Abstract;
using TekhnelogosOkr.DataAccess.Concrete.Context;
using TekhnelogosOkr.Entity.Concrete;

namespace TekhnelogosOkr.DataAccess.Concrete.EntityFramework
{
    public class EfKeyResultTransactionDal : EfEntityRepositoryBase<KeyResultTransaction, TekhnelogosOkrContext>, IKeyResultTransactionDal
    {
        public EfKeyResultTransactionDal(TekhnelogosOkrContext context) : base(context)
        {
        }
    }
}

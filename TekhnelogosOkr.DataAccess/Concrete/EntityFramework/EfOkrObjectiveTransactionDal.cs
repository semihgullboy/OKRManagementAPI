using Microsoft.EntityFrameworkCore;
using TekhnelogosOkr.Core.DataAccess.Concrete.EntityFramework;
using TekhnelogosOkr.DataAccess.Abstract;
using TekhnelogosOkr.DataAccess.Concrete.Context;
using TekhnelogosOkr.Entity.Concrete;
using TekhnelogosOkr.ViewModel.Objective;
using TekhnelogosOkr.ViewModel.OkrObjectiveTransaction;

namespace TekhnelogosOkr.DataAccess.Concrete.EntityFramework
{
    public class EfOkrObjectiveTransactionDal : EfEntityRepositoryBase<OkrObjectiveTransaction, TekhnelogosOkrContext>, IOkrObjectiveTransactionDal
    {
        public EfOkrObjectiveTransactionDal(TekhnelogosOkrContext context) : base(context)
        {
        }
    }
}

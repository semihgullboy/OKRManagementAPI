using TekhnelogosOkr.Core.DataAccess.Abstract;
using TekhnelogosOkr.Entity.Concrete;
using TekhnelogosOkr.ViewModel.OkrObjectiveTransaction;

namespace TekhnelogosOkr.DataAccess.Abstract
{
    public interface IOkrObjectiveTransactionDal : IEntityRepository<OkrObjectiveTransaction>
    {
    }
}

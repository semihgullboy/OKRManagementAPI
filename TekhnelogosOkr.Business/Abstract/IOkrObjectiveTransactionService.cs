using TekhnelogosOkr.Core.Utilities.Results;
using TekhnelogosOkr.ViewModel.Objective;
using TekhnelogosOkr.ViewModel.OkrObjectiveTransaction;

namespace TekhnelogosOkr.Business.Abstract
{
    public interface IOkrObjectiveTransactionService
    {
        Task<IResult> CreateOkrObjectiveTransaction(AddOkrObjectiveTransactionViewModel okrObjectiveTransactionViewModel);
        Task<IDataResult<OkrObjectiveTViewModel>> GetOkrObjectiveTransactionAsync(int okrObjectiveId);
    }
}

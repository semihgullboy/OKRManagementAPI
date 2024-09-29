using TekhnelogosOkr.Core.Utilities.Results;
using TekhnelogosOkr.ViewModel.KeyResultTransaction;

namespace TekhnelogosOkr.Business.Abstract
{
    public interface IKeyResultTransactionService
    {
        Task<IResult> CreateKeyResultTransaction(AddKeyResultTransactionViewModel addKeyResultTransactionViewModel);
    }
}

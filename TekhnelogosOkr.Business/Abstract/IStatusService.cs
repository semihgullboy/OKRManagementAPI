using TekhnelogosOkr.Core.Utilities.Results;
using TekhnelogosOkr.ViewModel.Status;

namespace TekhnelogosOkr.Business.Abstract
{
    public interface IStatusService
    {
        Task<IDataResult<List<StatusViewModel>>> GetAllStatusesAsync();
    }
}
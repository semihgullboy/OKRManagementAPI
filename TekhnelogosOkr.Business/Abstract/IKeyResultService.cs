using TekhnelogosOkr.Core.Utilities.Results;
using TekhnelogosOkr.ViewModel.KeyResult;
namespace TekhnelogosOkr.Business.Abstract
{
    public interface IKeyResultService
    {
        Task<IDataResult<int>> CreateKeyResultAsync(AddKeyResultViewModel keyResultViewModel);
        Task<IResult> DeleteKeyResultAsync(int id);
        Task<IResult> UpdateKeyResultAsync(UpdateKeyResultViewModel keyResultViewModel, int id);


    }
}

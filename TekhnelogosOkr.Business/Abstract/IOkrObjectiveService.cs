using TekhnelogosOkr.Core.Utilities.Results;
using TekhnelogosOkr.ViewModel.Objective;

namespace TekhnelogosOkr.Business.Abstract
{
    public interface IOkrObjectiveService
    {
        Task<IResult> CreateDepartmanObjectiveAsync(AddDepartmentOkrObjectiveViewModel objectiveViewModel);

        Task<IResult> CreateObjectiveAsync(AddOkrObjectiveViewModel objectiveViewModel);

        Task<IResult> UpdateOkrObjectiveAsync(UpdateOkrObjectiveViewModel objectiveViewModel, int id);

        Task<IResult> UpdateDepartmentOkrObjectiveAsync(UpdateDepartmentOkrObjectiveViewModel objectiveViewModel, int id);

        Task<IResult> DeleteObjectiveAsync(int id);

        Task<IDataResult<List<OkrObjectiveViewModel>>> GetOkrObjectivesByUserIdAsync(int userId);
    }
}
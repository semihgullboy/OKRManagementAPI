using TekhnelogosOkr.Core.Utilities.Results;
using TekhnelogosOkr.ViewModel.CompanyObjective;

namespace TekhnelogosOkr.Business.Abstract
{
    public interface ICompanyObjectiveService
    {
        Task<IResult> CreateCompanyObjectiveAsync(AddCompanyObjectiveViewModel companyObjectiveViewModel);

        Task<IDataResult<List<CompanyObjectiveViewModel>>> GetAllCompanyObjectivesAsync();

        Task<IResult> DeleteCompanyObjectiveAsync(int id);

        Task<IResult> UpdateCompanyObjectiveAsync(UpdateCompanyObjectiveViewModel companyObjectiveViewModel, int id);

        Task<IDataResult<CompanyObjectiveDetailViewModel>> GetCompanyObjectiveWithOkrObjectivesAsync(int companyObjectiveId);
    }
}
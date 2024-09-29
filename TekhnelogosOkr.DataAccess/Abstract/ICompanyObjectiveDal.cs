using TekhnelogosOkr.Core.DataAccess.Abstract;
using TekhnelogosOkr.Entity.Concrete;
using TekhnelogosOkr.ViewModel.CompanyObjective;

namespace TekhnelogosOkr.DataAccess.Abstract
{
    public interface ICompanyObjectiveDal : IEntityRepository<CompanyObjective>
    {
        Task<CompanyObjectiveDetailViewModel> GetCompanyObjectiveWithOkrObjectivesAsync(int companyObjectiveId);
    }
}
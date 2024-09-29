using TekhnelogosOkr.Core.DataAccess.Abstract;
using TekhnelogosOkr.Entity.Concrete;
using TekhnelogosOkr.ViewModel.Objective;

namespace TekhnelogosOkr.DataAccess.Abstract
{
    public interface IOkrObjectiveDal : IEntityRepository<OkrObjective>
    {
        Task<List<OkrObjectiveViewModel>> GetOkrObjectivesByUserIdAsync(int userId);
        Task<OkrObjectiveTViewModel> GetOkrObjectiveWithTransactionsAsync(int okrObjectiveId);
    }
}
using Microsoft.EntityFrameworkCore;
using TekhnelogosOkr.Core.DataAccess.Concrete.EntityFramework;
using TekhnelogosOkr.DataAccess.Abstract;
using TekhnelogosOkr.DataAccess.Concrete.Context;
using TekhnelogosOkr.Entity.Concrete;
using TekhnelogosOkr.ViewModel.KeyResult;
using TekhnelogosOkr.ViewModel.Objective;
using TekhnelogosOkr.ViewModel.OkrObjectiveTransaction;

namespace TekhnelogosOkr.DataAccess.Concrete.EntityFramework
{
    public class EfOkrObjectiveDal : EfEntityRepositoryBase<OkrObjective, TekhnelogosOkrContext>, IOkrObjectiveDal
    {
        private readonly TekhnelogosOkrContext _context;

        public EfOkrObjectiveDal(TekhnelogosOkrContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<OkrObjectiveViewModel>> GetOkrObjectivesByUserIdAsync(int userId)
        {
            var objectives = await _context.OkrObjectiveUsers
                .Where(ou => ou.UserId == userId)
                .Select(ou => ou.Objective)
                .Where(o => o.IsActive)
                .Select(o => new OkrObjectiveViewModel
                {
                    Id = o.Id,
                    Title = o.Title,
                    CreatedDate = o.CreatedDate,
                    UpdatedDate = o.UpdatedDate,
                    Weight = o.Weight,
                    Progress = o.Progress,
                    StatusId = o.StatusId,
                    CreatedByUserName = o.OkrObjectiveUsers
                                    .Where(ou => ou.Objective.Id == o.Id)
                                    .Select(ou => $"{ou.User.FirstName} {ou.User.LastName}")
                                    .FirstOrDefault(),
                    KeyResults = o.KeyResults
                                .Where(o => o.IsActive)
                                .Select(kr => new KeyResultViewModel
                                {
                                    Id = kr.Id,
                                    Title = kr.Title,
                                    TargetDate = kr.TargetDate,
                                    CreatedDate = kr.CreatedDate,
                                    Progress = kr.Progress
                                })
                                .ToList()
                })
                .ToListAsync();

            return objectives;
        }

        public async Task<OkrObjectiveTViewModel> GetOkrObjectiveWithTransactionsAsync(int okrObjectiveId)
        {
            var objective = await _context.OkrObjectives
                .Where(o => o.Id == okrObjectiveId && o.IsActive)
                .Include(o => o.OkrObjectiveTransactions)
                .ThenInclude(t => t.UpdatedByUser)
                .ToListAsync();

            if (objective == null || !objective.Any())
            {
                return null;
            }

            var totalWeight = objective.Sum(o => o.Weight);

            var okrObjective = objective.First();

            var viewModel = new OkrObjectiveTViewModel
            {
                Id = okrObjective.Id,
                Title = okrObjective.Title,
                Weight = okrObjective.Weight,
                CreatedDate = okrObjective.CreatedDate,
                UpdatedDate = okrObjective.UpdatedDate,
                Progress = okrObjective.Progress,
                TotalWeight = totalWeight,
                StatusId = okrObjective.StatusId,
                OkrObjectiveTransactionViewModels = okrObjective.OkrObjectiveTransactions
                    .Select(t => new OkrObjectiveTransactionViewModel
                    {
                        Id = t.Id,
                        Content = t.Content,
                        UpdatedByUserFullName = $"{t.UpdatedByUser.FirstName} {t.UpdatedByUser.LastName}",
                        UpdatedDate = t.UpdatedDate
                    }).ToList()
            };

            return viewModel;
        }
    }
}
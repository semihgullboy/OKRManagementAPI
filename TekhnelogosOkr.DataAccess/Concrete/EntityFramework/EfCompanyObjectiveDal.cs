using Microsoft.EntityFrameworkCore;
using TekhnelogosOkr.Core.DataAccess.Concrete.EntityFramework;
using TekhnelogosOkr.DataAccess.Abstract;
using TekhnelogosOkr.DataAccess.Concrete.Context;
using TekhnelogosOkr.Entity.Concrete;
using TekhnelogosOkr.ViewModel.CompanyObjective;
using TekhnelogosOkr.ViewModel.KeyResult;
using TekhnelogosOkr.ViewModel.Objective;

namespace TekhnelogosOkr.DataAccess.Concrete.EntityFramework
{
    public class EfCompanyObjectiveDal : EfEntityRepositoryBase<CompanyObjective, TekhnelogosOkrContext>, ICompanyObjectiveDal
    {
        private readonly TekhnelogosOkrContext _context;

        public EfCompanyObjectiveDal(TekhnelogosOkrContext context) : base(context)
        {
            _context = context;
        }

        public async Task<CompanyObjectiveDetailViewModel> GetCompanyObjectiveWithOkrObjectivesAsync(int companyObjectiveId)
        {
            var companyObjective = await _context.CompanyObjectives
                .Include(co => co.CompanyObjectiveOkrObjectives)
                .ThenInclude(coo => coo.Objective)
                .ThenInclude(o => o.OkrObjectiveUsers)
                .ThenInclude(ou => ou.User)
                .FirstOrDefaultAsync(co => co.Id == companyObjectiveId && co.IsActive);

            if (companyObjective == null)
            {
                return null;
            }

            var okrObjectives = companyObjective.CompanyObjectiveOkrObjectives
                 .Where(coo => coo.Objective.IsActive && coo.Objective.StatusId != 3)
         .Select(coo => new OkrObjectiveViewModel
         {
             Id = coo.Objective.Id,
             Title = coo.Objective.Title,
             CreatedDate = coo.Objective.CreatedDate,
             Weight = coo.Objective.Weight,
             Progress = coo.Objective.Progress,
             StatusId = coo.Objective.StatusId,
             CreatedByUserName = coo.Objective.OkrObjectiveUsers.Any()
                ? $"{coo.Objective.OkrObjectiveUsers.First().User.FirstName} {coo.Objective.OkrObjectiveUsers.First().User.LastName}"
                : "Unknown"
         }).ToList();

            var totalWeight = okrObjectives.Sum(o => o.Weight);

            okrObjectives.ForEach(o => o.TotalWeight = totalWeight);

            return new CompanyObjectiveDetailViewModel
            {
                Id = companyObjective.Id,
                Title = companyObjective.Title,
                Weight = companyObjective.Weight,
                CreatedDate = companyObjective.CreatedDate,
                Progress = companyObjective.Progress,
                StatusId = companyObjective.StatusId,
                OkrObjectives = okrObjectives
            };
        }
    }
}
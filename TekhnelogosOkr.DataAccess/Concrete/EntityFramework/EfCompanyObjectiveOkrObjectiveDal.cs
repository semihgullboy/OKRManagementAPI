using TekhnelogosOkr.Core.DataAccess.Concrete.EntityFramework;
using TekhnelogosOkr.DataAccess.Abstract;
using TekhnelogosOkr.DataAccess.Concrete.Context;
using TekhnelogosOkr.Entity.Concrete;

namespace TekhnelogosOkr.DataAccess.Concrete.EntityFramework
{
    public class EfCompanyObjectiveOkrObjectiveDal : EfEntityRepositoryBase<CompanyObjectiveOkrObjective, TekhnelogosOkrContext>, ICompanyObjectiveOkrObjectiveDal
    {
        public EfCompanyObjectiveOkrObjectiveDal(TekhnelogosOkrContext context) : base(context)
        {
        }
    }
}
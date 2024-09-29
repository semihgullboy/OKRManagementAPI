using TekhnelogosOkr.Core.DataAccess.Concrete.EntityFramework;
using TekhnelogosOkr.DataAccess.Abstract;
using TekhnelogosOkr.DataAccess.Concrete.Context;
using TekhnelogosOkr.Entity.Concrete;

namespace TekhnelogosOkr.DataAccess.Concrete.EntityFramework
{
    public class EfKeyResultOkrObjectiveDal : EfEntityRepositoryBase<KeyResultOkrObjective, TekhnelogosOkrContext>, IKeyResultOkrObjectiveDal
    {
        public EfKeyResultOkrObjectiveDal(TekhnelogosOkrContext context) : base(context)
        {
        }
    }
}

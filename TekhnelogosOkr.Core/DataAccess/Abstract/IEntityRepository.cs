using System.Linq.Expressions;

namespace TekhnelogosOkr.Core.DataAccess.Abstract
{
    public interface IEntityRepository<TEntity>
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null);
        Task AddAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}



using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TekhnelogosOkr.Core.DataAccess.Abstract;
using TekhnelogosOkr.Core.Entities.Concrete;

namespace TekhnelogosOkr.Core.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        private readonly TContext _context;

        public EfEntityRepositoryBase(TContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            if (entity is BaseEntity baseEntity)
            {
                baseEntity.IsActive = false;
                _context.Set<TEntity>().Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? await _context.Set<TEntity>().ToListAsync()
                : await _context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

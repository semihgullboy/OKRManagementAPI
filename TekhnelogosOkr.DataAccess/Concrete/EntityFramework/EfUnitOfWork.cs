using Microsoft.EntityFrameworkCore.Storage;
using TekhnelogosOkr.DataAccess.Abstract;
using TekhnelogosOkr.DataAccess.Concrete.Context;

namespace TekhnelogosOkr.DataAccess.Concrete.EntityFramework
{
    public class EfUnitOfWork : IUnitOfWork
    {
        //TRANSACTİON İŞLEMİ İÇİN (TEKHNECAFE PROJESİNDEN ALDIM)

        private readonly TekhnelogosOkrContext _context;
        private IDbContextTransaction _transaction;

        public EfUnitOfWork(TekhnelogosOkrContext context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                _transaction.Dispose();
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                _transaction.Dispose();
            }
        }
    }
}
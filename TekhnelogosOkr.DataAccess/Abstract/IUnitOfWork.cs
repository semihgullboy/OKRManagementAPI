namespace TekhnelogosOkr.DataAccess.Abstract
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync();

        Task CommitTransactionAsync();

        Task RollbackTransactionAsync();
    }
}
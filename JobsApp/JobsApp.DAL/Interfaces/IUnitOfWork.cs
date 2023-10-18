using JobsApp.Domain.Entities.Base;

namespace JobsApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity, new();

        Task SaveChangesAsync();

        Task RunInTransactionAsync(Func<Task> asyncAction);
    }
}
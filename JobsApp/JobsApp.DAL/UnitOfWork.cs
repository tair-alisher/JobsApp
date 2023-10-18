using System.Collections.Concurrent;
using JobsApp.DAL.Interfaces;
using JobsApp.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace JobsApp.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly ConcurrentDictionary<Type, IRepository> _repositories;

        public UnitOfWork(IContextFactory contextFactory)
        {
            _context = contextFactory.Create();
            _repositories = new ConcurrentDictionary<Type, IRepository>();
        }

        public void Dispose()
        {
            _repositories.Clear();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity, new() =>
            _repositories.GetOrAdd(typeof(TEntity), x => new Repository<TEntity>(_context)) as IRepository<TEntity>;

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();

        public async Task RunInTransactionAsync(Func<Task> asyncAction)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            await asyncAction.Invoke();
            await transaction.CommitAsync();
        }
    }
}
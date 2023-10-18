using System.Linq.Expressions;
using JobsApp.Domain.Entities.Base;

namespace JobsApp.DAL.Interfaces
{
    public interface IRepository
    {
    }

    public interface IRepository<TEntity> : IRepository where TEntity : class, IEntity, new()
    {
        IQueryable<TEntity> All();

        Task<TEntity> GetByIdAsync(params object[] id);

        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TEntity entity);

        Task AddAsync(IEnumerable<TEntity> entities);

        void Udpate(TEntity entity);

        void Update(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);

        Task DeleteAsync(params object[] id);

        void Delete(IEnumerable<TEntity> entities);
    }
}
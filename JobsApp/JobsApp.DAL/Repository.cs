using System.Linq.Expressions;
using JobsApp.DAL.Interfaces;
using JobsApp.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace JobsApp.DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
            => await _context.AddAsync(entity);

        public async Task AddAsync(IEnumerable<TEntity> entities)
            => await _context.AddRangeAsync(entities);

        public IQueryable<TEntity> All() => _context.Set<TEntity>();

        public void Delete(TEntity entity) => _context.Remove(entity);

        public void Delete(IEnumerable<TEntity> entities) => _context.RemoveRange(entities);

        public async Task DeleteAsync(params object[] id)
        {
            TEntity entity = await _context.FindAsync<TEntity>(id);
            if (entity != null) _context.Remove(entity);
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
            => await _context.Set<TEntity>().SingleOrDefaultAsync(predicate);

        public async Task<TEntity> GetByIdAsync(params object[] id)
            => await _context.FindAsync<TEntity>(id);

        public void Udpate(TEntity entity)
            => _context.Update(entity);

        public void Update(IEnumerable<TEntity> entities) =>
            _context.UpdateRange(entities);
    }
}
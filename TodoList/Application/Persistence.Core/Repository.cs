using Core;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Core
{
    public class Repository<T> : ReadOnlyRepository<T>, IRepository<T>, IReadOnlyRepository<T>, IDisposable where T : class
    {
        public Repository(IContext context)
            : base(context)
        {
        }

        public virtual async Task AddOrUpdateAsync(T entity, CancellationToken cancellationToken)
        {
            if (IsItNew(entity))
            {
                await _dbContext.AddAsync(entity, cancellationToken);
                return;
            }

            await Task.Run(() => _dbContext.Update(entity));
        }

        public virtual async Task AddOrUpdateAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
        {
            foreach (T item in entities.ToList())
            {
                await AddOrUpdateAsync(item, cancellationToken);
            }
        }

        public virtual async Task AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _dbContext.AddAsync(entity, cancellationToken);
        }

        public virtual async Task AddAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
        {
            await _dbContext.AddRangeAsync(entities, cancellationToken);
        }

        public virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            await Task.Run(() => _dbContext.Update(entity), cancellationToken);
        }

        public virtual async Task UpdateAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
        {
            await Task.Run(delegate
            {
                _dbContext.UpdateRange(entities);
            }, cancellationToken);
        }

        public virtual void RemoveByKey(params object[] keyValues)
        {
            T val = _dbContext.Set<T>().Find(keyValues);
            if (val != null)
            {
                Remove(val);
            }
        }

        public virtual void Remove(T entity)
        {
            if (entity != null)
            {
                _dbContext.Set<T>().Attach(entity);
                _dbContext.Set<T>().Remove(entity);
            }
        }

        public virtual void Remove(IEnumerable<T> entities)
        {
            entities?.ToList().ForEach(delegate (T entity)
            {
                Remove(entity);
            });
        }

        private bool IsItNew(object entity)
        {
            return !_dbContext.Entry(entity).IsKeySet;
        }
    }
}

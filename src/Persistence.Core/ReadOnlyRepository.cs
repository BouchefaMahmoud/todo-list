using Microsoft.EntityFrameworkCore;
using Core;

namespace Persistence.Core
{
    public class ReadOnlyRepository<T> : IReadOnlyRepository<T>, IDisposable where T : class
    {
        protected readonly DbContextBase _dbContext;

        protected DbContextBase DbContext => _dbContext;

        public ReadOnlyRepository(IContext context)
        {
            _dbContext = context as DbContextBase;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public virtual async Task<T> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            return await _dbContext.Set<T>().FindAsync(keyValues);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }
    }
}

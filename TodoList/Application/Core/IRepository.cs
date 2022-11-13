namespace Core
{
    public interface IRepository<T> : IReadOnlyRepository<T>, IDisposable
    {
        [Obsolete("Use Add or Update version instead AddOrUpdate")]
        Task AddOrUpdateAsync(T entity, CancellationToken cancellationToken);

        [Obsolete("Use Add or Update version instead AddOrUpdate")]
        Task AddOrUpdateAsync(IEnumerable<T> entities, CancellationToken cancellationToken);

        Task AddAsync(T entity, CancellationToken cancellationToken);

        Task AddAsync(IEnumerable<T> entities, CancellationToken cancellationToken);

        Task UpdateAsync(T entity, CancellationToken cancellationToken);

        Task UpdateAsync(IEnumerable<T> entities, CancellationToken cancellationToken);

        void RemoveByKey(params object[] keyValues);

        void Remove(T entity);

        void Remove(IEnumerable<T> entities);
    }
}
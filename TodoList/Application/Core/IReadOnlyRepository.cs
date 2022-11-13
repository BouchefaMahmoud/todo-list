
namespace Core
{
    public interface IReadOnlyRepository<T> : IDisposable
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);

        Task<T> FindAsync(CancellationToken cancellationToken, params object[] keyValues);
    }
}

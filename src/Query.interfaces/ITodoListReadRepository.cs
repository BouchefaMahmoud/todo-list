using Domain.Entities;
using Core;

namespace Query.interfaces
{
    public interface ITodoListReadRepository : IRepository<Todo>
    {
        public Task<Todo> FindTodoListByIdAsync(Guid TodoListId, CancellationToken token);

    }
}

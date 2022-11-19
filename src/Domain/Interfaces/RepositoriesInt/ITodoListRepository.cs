using Core;
using Domain.Entities;

namespace Domain.Interfaces.RepositoriesInt
{
    public interface ITodoListRepository : IRepository<Todo>
    {
        public Task<Todo> FindTodoListByIdAsync(Guid TodoListId, CancellationToken token);
    }
}

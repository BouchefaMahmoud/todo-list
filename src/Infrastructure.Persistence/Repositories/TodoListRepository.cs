using Domain.Entities;
using Domain.Interfaces.RepositoriesInt;
using Infrastructure.Persistence.ContextInt;
using Microsoft.EntityFrameworkCore;
using Persistence.Core;

namespace Infrastructure.Persistence.Repositories
{
    public class TodoListRepository : Repository<Todo>, ITodoListRepository
    {
        private readonly ITodoListContext _context;
        public TodoListRepository(ITodoListContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Todo> FindTodoListByIdAsync(Guid TodoListId, CancellationToken token)
        {
            return await _context.TodoList.Where(t => t.Id == TodoListId).FirstAsync();
        }
    }
}
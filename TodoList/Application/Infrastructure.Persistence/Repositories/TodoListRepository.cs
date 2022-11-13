using Domain.Entities;
using Domain.Interfaces.RepositoriesInt;
using Infrastructure.Persistence.ContextInt;
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

    }
}
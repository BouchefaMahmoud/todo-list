using Domain.Entities;
using Infrastructure.Persistence.ContextInt;
using Persistence.Core;
using Domain.Interfaces.RepositoriesInt;

namespace Infrastructure.Persistence.Repositories
{
    public class TaskRepository : Repository<TaskItem>, ITaskRepository
    {
        private readonly ITodoListContext _context;

        public TaskRepository(ITodoListContext context) : base(context)
        {
            _context = context;
        }
    }
}

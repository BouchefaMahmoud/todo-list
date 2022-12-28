using System;
using System.Collections.Generic;
using Persistence.Core;
using Domain.Entities;
using Query.interfaces;
using Infrastructure.Persistence.ContextInt;
using Microsoft.EntityFrameworkCore;

namespace Query.Services
{
    public class TodoListReadRepository : Repository<Todo>, ITodoListReadRepository
    {
        private readonly ITodoListContext _context;
     
        public TodoListReadRepository(ITodoListContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Todo> FindTodoListByIdAsync(Guid TodoListId, CancellationToken token)
        {
            return await _context.TodoList.Where(t => t.Id == TodoListId).FirstAsync();
        }
    }
}

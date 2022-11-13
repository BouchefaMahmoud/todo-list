using System;
using System.Collections.Generic;
using Persistence.Core;
using Domain.Entities;
using Query.interfaces;
using Infrastructure.Persistence.ContextInt;

namespace Query.Services
{
    public class TodoListReadRepository : Repository<TaskItem>, ITodoListReadRepository
    {
        private readonly ITodoListContext _context;
     
        public TodoListReadRepository(ITodoListContext context) : base(context)
        {
            _context = context;
        }

    }
}

using System;
using System.Collections.Generic;
using Persistence.Core;
using Domain.Entities;
using Query.interfaces;
using Infrastructure.Persistence.ContextInt;

namespace Query.Services
{
    public class TaskReadRepository : Repository<TaskItem>, ITaskReadRepository
    {
        private readonly ITodoListContext _context;

     
        public TaskReadRepository(ITodoListContext context) : base(context)
        {
            _context = context;
        }
    }
}

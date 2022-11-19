using Persistence.Core;
using Core;
using Domain.Interfaces;
using Domain.Interfaces.RepositoriesInt;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Persistence.ContextInt;
using Infrastructure.Persistence.ContextImpl;

namespace Infrastructure.Persistence
{
    public class TodoListUnitOfWork : UnitOfWork<TodoListContext>, ITodoListUnitOfWork
    {
        private readonly IServiceProvider _serviceProvider;

        private ITodoListRepository todoListRepository = null!;
        private ITaskRepository taskRepository = null!;

        public TodoListUnitOfWork(ITodoListContext context, IServiceProvider serviceProvider) : base(context)
        {
            _serviceProvider = serviceProvider;
        }

        public ITodoListRepository TodoListRepository
        {
            get
            {
                return todoListRepository ??= _serviceProvider.GetRequiredService<ITodoListRepository>();
            }
        }

        public ITaskRepository TaskRepository
        {
            get
            {
                return taskRepository ??= _serviceProvider.GetRequiredService<ITaskRepository>();
            }
        }

        /*
         * Optionnel : Audit
         */
        #region
        public Task AddAuditTrailAsync<T>(T entity, string label = null) where T : Entity
        {
            ITodoListContext ctx = Context as TodoListContext;
            ctx?.AddAuditTrailAsync(entity, label);
            return Task.CompletedTask;
        }
        #endregion
    }





}

using Core;
using Domain.Interfaces.RepositoriesInt;


namespace Domain.Interfaces
{
    public interface ITodoListUnitOfWork : IUnitOfWork
    {
        public ITodoListRepository TodoListRepository { get;}
        public ITaskRepository TaskRepository { get; }

        
        /*
         * Optionnel : Audit
         */

        #region Audit 
         Task AddAuditTrailAsync<T>(T entity, string label = null) where T : Entity;
        #endregion

    }
}

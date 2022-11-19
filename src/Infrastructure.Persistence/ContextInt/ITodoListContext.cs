using Core;
using Core.Audit;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.ContextInt
{
    public interface ITodoListContext : IContext
    {
        DbSet<AuditTrail> AuditTrails { get; set; }
        DbSet<TaskItem> TaskList { get; set; }
        DbSet<Todo> TodoList { get; set; }

        /*
         * Optionnel : Audit
         */
        #region Audit
            Task AddAuditTrailAsync<T>(T entity, string label = null) where T : Entity;
        #endregion

    }
}
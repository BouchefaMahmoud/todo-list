using Domain.Entities;
using Persistence.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Core.Security;
using Core;
using Core.Audit;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Infrastructure.Persistence.ContextInt;

namespace Infrastructure.Persistence.ContextImpl
{
    public class TodoListContext : DbContextBase, ITodoListContext
    {
        private readonly string _userId;
        private readonly string _userName;

        public TodoListContext(DbContextOptions options, ILogger<DbContextBase> loggerService, IUserService userService)
           : base(options, loggerService, userService)
        {
            _userId = userService.GetSubjectId();
            _userName = userService.GetName();
        }

        public DbSet<Todo> TodoList { get; set; } = null!;
        public DbSet<TaskItem> TaskList { get; set; } = null!;
        public DbSet<AuditTrail> AuditTrails { get; set; } = null!;



        /*
         * Optionnel : Ajouter l'audit 
         */

        #region audit

        /// <summary>
        /// Called before save changes.
        /// </summary>
        protected override void OnBeforeSaveChanges()
        {
            UseAuditable();
            UseSoftDelete();
            base.OnBeforeSaveChanges();
        }

        /// <summary>
        /// Add audit trail
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="entity">The entity</param>
        public Task AddAuditTrailAsync<T>(T entity, string label = null) where T : Entity
        {
            DbSet<AuditTrail> dbSet = AuditTrails;
            var transactionId = Guid.NewGuid();
            var entry = Entry(entity);
            var keys = entry?.Properties.Where(p => p.Metadata.IsKey()).Select(ki => new AuditTrailPropertyInfo { Key = ki.Metadata.Name, Value = ki.CurrentValue }).ToList();

            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };

            var auditTrail = new AuditTrail
            {
                Label = label,
                EntityKeys = JsonSerializer.Serialize(keys),
                EntityName = entry.Metadata.Name,
                CreatedDate = DateTimeOffset.Now,
                CreatedBy = _userName,
                CreatedById = _userId,
                Action = entry.State.ToString(),
                TransactionId = transactionId,
                CurrentValues = JsonSerializer.Serialize(entry.Entity, entry.Entity.GetType(), options),
            };

            dbSet.Add(auditTrail);

            return Task.CompletedTask;
        }

        #endregion 

    }
}

using System;
using System.ComponentModel.DataAnnotations;
using Core;

namespace Core.Audit
{
    /// <summary>
    /// Audit trail entity
    /// </summary>
    public class AuditTrail : Entity
    {
        [Key]
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the transaction id.
        /// </summary>
        public Guid TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the label
        /// </summary>
        [StringLength(500)]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the entity keys
        /// </summary>
        [StringLength(500)]
        public string EntityKeys { get; set; }

        /// <summary>
        /// Gets or sets the entity name
        /// </summary>
        [StringLength(100)]
        public string EntityName { get; set; }

        /// <summary>
        /// Gets or sets the action
        /// </summary>
        [StringLength(100)]
        public string Action { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        [Required]
        public DateTimeOffset CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        [StringLength(100)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created by identifier.
        /// </summary>
        [StringLength(100)]
        public string CreatedById { get; set; }

        /// <summary>
        /// Gets or sets the current properties values
        /// </summary>
        public string CurrentValues { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Libelle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<TaskItem>? Tasks { get; set; } = null!;

    }
}

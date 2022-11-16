using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UseCases.AddTodoList
{
    public class AddTodoListCommand : IRequest<Guid>
    {
        public string Libelle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}

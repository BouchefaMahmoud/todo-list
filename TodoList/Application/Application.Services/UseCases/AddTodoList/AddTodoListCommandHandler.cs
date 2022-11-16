using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UseCases.AddTodoList
{
    public class AddTodoListCommandHandler : IRequestHandler<AddTodoListCommand, Guid>
    {
        private readonly ITodoListUnitOfWork _unitOfWork;
        private readonly ILogger<AddTodoListCommandHandler> _logger;

        public AddTodoListCommandHandler(ITodoListUnitOfWork unitOfWork, ILogger<AddTodoListCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Guid> Handle(AddTodoListCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.TodoListRepository.AddAsync(new Todo
            {
                Description = request.Description,
                Libelle = request.Libelle
            }, cancellationToken);

            await _unitOfWork.SaveAsync();

            return Guid.Empty;  
        }
    }
}

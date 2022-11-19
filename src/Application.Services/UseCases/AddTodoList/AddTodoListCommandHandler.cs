using AutoMapper;
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
        private readonly IMapper _mapper;

        public AddTodoListCommandHandler(ITodoListUnitOfWork unitOfWork, ILogger<AddTodoListCommandHandler> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AddTodoListCommand command, CancellationToken cancellationToken)
        {
           if (command == null) throw new ArgumentNullException("Dto vide");

            var todo = _mapper.Map<Todo>(command);

            await _unitOfWork.TodoListRepository.AddAsync(todo, cancellationToken);

            await _unitOfWork.SaveAsync();

            return todo.Id;  
        }
    }
}

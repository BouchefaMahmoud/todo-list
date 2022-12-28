using Application.Services.UseCases.GetAllTodoLists;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using Query.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UseCases.GetTodoListById
{
    public class GetTodoListByIdRequestHandler : IRequestHandler<GetTodoListByIdRequest, Todo>
    {

        private readonly ITodoListReadRepository _todoListReadRepository;
        private readonly ILogger<GetAllTodoListsRequestHandler> _logger;
        private IMapper _mapper;

        public GetTodoListByIdRequestHandler(ITodoListReadRepository todoListReadRepository, ILogger<GetAllTodoListsRequestHandler> logger, IMapper mapper)
        {
            _todoListReadRepository = todoListReadRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Todo> Handle(GetTodoListByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await _todoListReadRepository.FindTodoListByIdAsync(request.Id, cancellationToken);
            return result;
        }
    }
}

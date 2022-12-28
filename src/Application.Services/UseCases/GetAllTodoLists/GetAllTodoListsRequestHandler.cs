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

namespace Application.Services.UseCases.GetAllTodoLists
{
    public class GetAllTodoListsRequestHandler : IRequestHandler<GetAllTodoListsRequest, IEnumerable<Todo>>
    {
        private readonly ITodoListReadRepository _todoListReadRepository;
        private readonly ILogger<GetAllTodoListsRequestHandler> _logger;
        private readonly IMapper _mapper;

        public GetAllTodoListsRequestHandler(ITodoListReadRepository todoListReadRepository, ILogger<GetAllTodoListsRequestHandler> logger, IMapper mapper)
        {
            _todoListReadRepository = todoListReadRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Todo>> Handle(GetAllTodoListsRequest request, CancellationToken cancellationToken)
        {
            var result = await _todoListReadRepository.GetAllAsync(cancellationToken);
            return result;
        }
    }
}

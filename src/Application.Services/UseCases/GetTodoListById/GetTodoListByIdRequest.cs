using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UseCases.GetTodoListById
{
    public class GetTodoListByIdRequest : IRequest<Todo>
    {
        public Guid Id { get;}

        public GetTodoListByIdRequest(Guid id)
        {
            Id = id;
        }
    }
}

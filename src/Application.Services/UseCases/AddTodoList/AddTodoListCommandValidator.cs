using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UseCases.AddTodoList
{
    public class AddTodoListCommandValidator : AbstractValidator<AddTodoListCommand>
    {
        public AddTodoListCommandValidator()
        {
            RuleFor(a => a.Libelle).NotEmpty().MaximumLength(200);
        }
    }
}

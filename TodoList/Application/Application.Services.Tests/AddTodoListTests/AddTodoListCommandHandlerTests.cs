using Application.Services.UseCases.AddTodoList;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.Services.Tests.AddTodoListTests
{
    public class AddTodoListCommandHandlerTests
    {
        private readonly Mock<ITodoListUnitOfWork> _mockUnitOfWork = new Mock<ITodoListUnitOfWork>();
        private readonly Mock<ILogger<AddTodoListCommandHandler>> _mockLogger = new Mock<ILogger<AddTodoListCommandHandler>>();

        [Fact]
        public async Task HandlerGivenValidCommandExpectOk()
        {
            //Arrange 
            var command = new Todo()
            {
                Libelle ="libelle",
                Description ="Description"
            };

            var handler = new AddTodoListCommandHandler(_mockUnitOfWork.Object, _mockLogger.Object);

           // _mockUnitOfWork.Setup(u => u.TodoListRepository.AddAsync(It.IsAny<Todo>(), It.IsAny<CancellationToken>())).ReturnAsync(Guid.NewGuid);
            
            
            //Act
           // var res = await handler.Handle(command, new CancellationToken());



            //Assert

        }
    }
}

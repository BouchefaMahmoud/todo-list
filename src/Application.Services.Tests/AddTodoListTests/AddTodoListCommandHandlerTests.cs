using Application.Services.UseCases.AddTodoList;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

using Xunit;

namespace Application.Services.Tests.AddTodoListTests
{
    public class AddTodoListCommandHandlerTests
    {
        private readonly Mock<ITodoListUnitOfWork> _mockUnitOfWork = new Mock<ITodoListUnitOfWork>();
        private readonly Mock<ILogger<AddTodoListCommandHandler>> _mockLogger = new Mock<ILogger<AddTodoListCommandHandler>>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [Fact]
        public async Task HandlerGivenValidCommandExpectOk()
        {
            //Arrange 
            var command = new AddTodoListCommand()
            {
                Libelle ="libelle",
                Description ="Description"
            };

            var todo = new Todo()
            {
                Id = Guid.NewGuid(),
                Libelle = "libelle",
                Description = "Description"
            };

            var handler = new AddTodoListCommandHandler(_mockUnitOfWork.Object, _mockLogger.Object, _mockMapper.Object);

            _mockUnitOfWork.Setup(u => u.TodoListRepository.AddAsync(It.IsAny<Todo>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            _mockMapper.Setup(m => m.Map<Todo>(command)).Returns(todo);
            
            //Act
            var res = await handler.Handle(command, new CancellationToken());


            //Assert
            res.Should().NotBeEmpty();
            res.Should().Be(todo.Id);

        }
    }
}

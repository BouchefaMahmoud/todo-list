using Application.Services.UseCases.AddTodoList;
using FluentAssertions;
using MediatR;
using Moq;
using TodoListApi.Controllers;
using Xunit;

namespace TodoList.Api.Tests.ControllersTests
{
    public class TodoListControllerTests
    {
        private readonly Mock<IMediator> _mediarMock = new(); 

        [Fact]
        public async Task AddTodoListCommandShoudReturnOk()
        {
            //Arrange
            var todoListController = new TodoListController(_mediarMock.Object);
            AddTodoListCommand addTodoListCommand = new AddTodoListCommand();

            //Act
            var result = await todoListController.Post(addTodoListCommand);

            //Assert
            result.Should().NotBeNull();

        }
    }
}

using Domain.Entities;
using FluentAssertions;
using Infrastructure.Persistence.Repositories;
using Xunit;

namespace Infrastructure.Persistence.Tests
{
    public class TodoListRepositoryTests
    {

        [Fact]
        public async Task FindTodoListByIdGivenCorrectIdExpectTodoList()
        {
            //Arrange
            var context = InMemoryContext.GetInMemoryContext();

            var todo = new Todo()
            {
                Id = Guid.NewGuid(),
                Libelle = "test",
                Description = "test"
            };

            await context.AddAsync(todo);
            await context.SaveChangesAsync();

            var respository = new TodoListRepository(context);


            //Act
            var res = await respository.FindTodoListByIdAsync(todo.Id, new CancellationToken());

            //Assert
            res.Id.Should().Be(todo.Id);

        }
    }
}

using Application.Services.UseCases.AddTodoList;
using FluentAssertions;
using Xunit;

namespace Application.Services.Tests.AddTodoListTests
{
    public class AddTodoListCommandValidatorTests
    {
        [Fact]
        public void GivenValidTodoListCommandExpectOk()
        {
            //Arrange
            var validator = new AddTodoListCommandValidator();
            var addTodoListCommand = new AddTodoListCommand()
            {
                Libelle = "ma Todo list",
                Description = "Quelque chose à faire"
            };

            //Act
            var res = validator.Validate(addTodoListCommand);   

            //Assert
            res.IsValid.Should().BeTrue();

        }

        [Fact]
        public void GivenInValidTodoListCommandExpectNotOk()
        {
            //Arrange
            var validator = new AddTodoListCommandValidator();
            var addTodoListCommand = new AddTodoListCommand()
            {
                Libelle = "",
                Description = "Quelque chose à faire"
            };

            //Act
            var res = validator.Validate(addTodoListCommand);

            //Assert
            res.IsValid.Should().BeFalse();

        }
    }
}

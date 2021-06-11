using mercadolibre_challenge.Application.Common.Exceptions;
using mercadolibre_challenge.Application.TodoLists.Commands.CreateTodoList;
using mercadolibre_challenge.Application.TodoLists.Commands.DeleteTodoList;
using mercadolibre_challenge.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace mercadolibre_challenge.Application.IntegrationTests.TodoLists.Commands
{
    using static Testing;

    public class DeleteTodoListTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoListId()
        {
            var command = new DeleteTodoListCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteTodoList()
        {
            var listId = await SendAsync(new CreateTodoListCommand
            {
                Title = "New List"
            });

            await SendAsync(new DeleteTodoListCommand 
            { 
                Id = listId 
            });

            var list = await FindAsync<TodoList>(listId);

            list.Should().BeNull();
        }
    }
}

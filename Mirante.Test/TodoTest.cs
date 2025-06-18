using Microsoft.EntityFrameworkCore;
using Mirante.Application.Services;
using Mirante.Data;
using Mirante.Model;
using Xunit;

namespace Mirante.Test
{
    public class TodoTest
    {
        [Fact]
        public async Task GetByDueDateAsync_Return_Something_filtered()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ToDoContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

            await using var context = new ToDoContext(options);
            context.Tasks.AddRange(
                new ToDo { Title = "A", Status = Tasks.Pending, DueDate = DateTime.Today },
                new ToDo { Title = "B", Status = Tasks.Done, DueDate = DateTime.Today }
            );
            await context.SaveChangesAsync();

            // Act
            var repo = new TasksRepository(context);

            var pending = await repo.GetByDueDateAsync(Tasks.Pending, null);
            Assert.Single(pending);

        }
    }
}

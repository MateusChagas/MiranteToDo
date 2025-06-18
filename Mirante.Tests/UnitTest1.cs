using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Mirante.Application.Repository;
using Mirante.Application.Services;
using Mirante.Data;
using Mirante.Model;

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
                new ToDo { Title = "A", Status = Tasks.Pending, DueDate = DateTime.Now },
                new ToDo { Title = "B", Status = Tasks.Done, DueDate = DateTime.Now }
            );
            await context.SaveChangesAsync();

            // Act
            var repo = new TasksRepository(context);

            // Assert
            IEnumerable<Tasks> pending = await repo.GetByDueDateAsync(Tasks.Pending,null);
            Assert.Single(pending);

        }
    }
}
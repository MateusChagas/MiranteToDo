using Microsoft.EntityFrameworkCore;
using Mirante.Model;

namespace Mirante.Data
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
        }
        public DbSet<ToDo> Tasks => Set<ToDo>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>()
                .HasIndex(t => new { t.Status, t.DueDate });
        }
    }

}

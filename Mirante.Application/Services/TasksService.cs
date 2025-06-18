using Microsoft.EntityFrameworkCore;
using Mirante.Application.Repository;
using Mirante.Data;
using Mirante.Model;

namespace Mirante.Application.Services
{
    public class TasksService: ITasksRepository
    {
        private readonly ToDoContext _context;

        public TasksService(ToDoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Tasks>> GetByDueDateAsync(Tasks? taskStatus, DateTime? dueDate)
        {
            var query = _context.Tasks.AsQueryable();
            if (taskStatus.HasValue)
            {
                query = query.Where(t => t.Status == taskStatus);

                if(dueDate.HasValue)
                    query = query.Where(t => t.DueDate.Date == dueDate.Value.Date);

            }
            return (IEnumerable<Tasks>)await query.ToListAsync();
        }
    }
}

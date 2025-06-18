using Mirante.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirante.Application.Repository
{
    public interface ITasksRepository
    {
        Task<IEnumerable<Tasks>> GetByDueDateAsync(Tasks? taskStatus, DateTime? dueDate);
    }
}

using Mirante.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirante.Application.Repository
{
    public interface IToDoRepository
    {
        Task<IEnumerable<ToDo>> GetAllAsync();
        Task<ToDo> GetByIdAsync(int id);
        Task<IEnumerable<ToDo>> GetByStatusAsync(Tasks status);
        Task<ToDo> AddAsync(ToDo todo);
        Task<ToDo> UpdateAsync(ToDo todo);
        Task<bool> DeleteAsync(int id);        

    }
}

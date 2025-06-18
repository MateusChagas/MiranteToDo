using Microsoft.EntityFrameworkCore;
using Mirante.Application.Repository;
using Mirante.Data;
using Mirante.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirante.Application.Services
{
    public class TodoRepository: IToDoRepository
    {
        private readonly ToDoContext _toDoContext;
        public TodoRepository(ToDoContext toDoContext)
        {
            _toDoContext = toDoContext ?? throw new ArgumentNullException(nameof(toDoContext));
        }

        public async Task<ToDo> AddAsync(ToDo todo)
        {
          var task = await _toDoContext.Tasks.AddAsync(todo);
            await _toDoContext.SaveChangesAsync();
            return task.Entity;
        }

        public void DeleteAsync(int? id)
        {
            var todo = _toDoContext.Tasks.Find(id);
            if (todo == null)
            {
                throw new KeyNotFoundException($"ToDo with ID {id} not found.");
            }
            _toDoContext.Tasks.Remove(todo);
            _toDoContext.SaveChanges();
            
        }

        public async Task<IEnumerable<ToDo>> GetAllAsync()
        {
            var todos = await _toDoContext.Tasks.ToListAsync();
            return todos;
        }

        public Task<ToDo> GetByIdAsync(int id)
        {
            var todo = _toDoContext.Tasks.FindAsync(id);
            if (todo == null)
            {
                throw new KeyNotFoundException($"ToDo with ID {id} not found.");
            }
            var task = todo.Result;
            return Task.FromResult(task);
        }

        public Task<IEnumerable<ToDo>> GetByStatusAsync(Tasks status)
        {
            var todos = _toDoContext.Tasks
                .Where(t => t.Status == status)
                .ToListAsync();
            if (todos == null)
            {
                throw new KeyNotFoundException($"No ToDo items found with status {status}.");
            }
            return Task.FromResult(todos.Result.AsEnumerable());
        }

        public Task<ToDo> UpdateAsync(ToDo todo)
        {
            var existingTodo = _toDoContext.Tasks.FindAsync(todo.Id);
            if (existingTodo == null)
            {
                throw new KeyNotFoundException($"ToDo with ID {todo.Id} not found.");
            }
            _toDoContext.Entry(existingTodo.Result).CurrentValues.SetValues(todo);
            _toDoContext.SaveChangesAsync();
            return Task.FromResult(existingTodo.Result);
        }

      
    }
}

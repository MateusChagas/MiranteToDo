using Microsoft.AspNetCore.Mvc;
using Mirante.Application.UnitOfWork;
using Mirante.Model;

namespace Mirante.Controllers
{
    public class ToDoController : Controller
    {
        [ApiController]
        [Route("api/[controller]")]
        public class ToDoTaskController : ControllerBase
        {
            private readonly IUnitOfWork _uow;
            public ToDoTaskController(IUnitOfWork uow)
            {
                _uow = uow;
            }
            [HttpGet]
            public async Task<IActionResult> GetAll([FromQuery] Tasks? status, [FromQuery] DateTime? dueDate)
            {
                var tasks = await _uow.TasksRepository.GetByDueDateAsync(status, dueDate);
                if (tasks == null || !tasks.Any())
                {
                    return NotFound("No tasks found.");
                }
                return Ok(tasks);
            }

            [HttpGet("{id:int}")]
            public async Task<IActionResult> GetById(int id)
            {
                var task = await _uow.ToDoRepository.GetByIdAsync(id);
                if (task == null)
                {
                    return NotFound($"Task with ID {id} not found.");
                }
                return Ok(task);
            }
            [HttpPost]
            public async Task<IActionResult> Create([FromBody] ToDo toDo)
            {
                if (toDo == null)
                {
                    return BadRequest("Task cannot be null.");
                }
                await _uow.ToDoRepository.AddAsync(toDo);
                await _uow.CommitAsync();
                return CreatedAtAction(nameof(GetById), new { id = toDo.Id }, toDo);
            }
            [HttpPut("{id:int}")]
            public async Task<IActionResult> Update(int id, [FromBody] ToDo toDo)
            {
                if (toDo == null || toDo.Id != id)
                {
                    return BadRequest("Task ID mismatch or task cannot be null.");
                }
                var existingTask = await _uow.ToDoRepository.GetByIdAsync(id);
                if (existingTask == null)
                {
                    return NotFound($"Task with ID {id} not found.");
                }
                existingTask.Title = toDo.Title;
                existingTask.Description = toDo.Description;
                existingTask.DueDate = toDo.DueDate;
                existingTask.Status = toDo.Status;
                await _uow.ToDoRepository.UpdateAsync(existingTask);
                await _uow.CommitAsync();
                return NoContent();
            }
           
            public async Task<IActionResult> Delete(int id)
            {
                var existingTask =  _uow.ToDoRepository.GetByIdAsync(id).Result;
                id = existingTask.Id;
                if (existingTask == null)
                {
                    return NotFound($"Task with ID {id} not found.");
                }
                _uow.ToDoRepository.DeleteAsync(id);
                await _uow.CommitAsync();
                return NoContent();
            }
        }

        }
    }
}

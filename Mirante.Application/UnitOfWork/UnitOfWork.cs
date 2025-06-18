using Mirante.Application.Repository;
using Mirante.Data;

namespace Mirante.Application.UnitOfWork
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly ToDoContext _context;
        private readonly IToDoRepository _toDoRepository;
        public UnitOfWork(ToDoContext context, IToDoRepository toDoRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _toDoRepository = toDoRepository ?? throw new ArgumentNullException(nameof(toDoRepository));
        }

        public IToDoRepository ToDoRepository => _toDoRepository;

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

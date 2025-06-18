using Mirante.Application.Repository;
using Mirante.Data;

namespace Mirante.Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ToDoContext _context;

        public IToDoRepository ToDoRepository { get; }

        public UnitOfWork(ToDoContext context, IToDoRepository toDoRepository)
        {
            _context = context;
            ToDoRepository = toDoRepository;
        }

        public async Task<int> CommitAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }

}

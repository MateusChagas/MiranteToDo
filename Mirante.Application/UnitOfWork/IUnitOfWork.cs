using Mirante.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirante.Application.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IToDoRepository ToDoRepository { get; } 
        Task<int> CommitAsync();
    }
    
}

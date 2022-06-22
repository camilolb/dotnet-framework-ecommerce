using System;
using System.Threading.Tasks;
using PruebaTecnica.Core.Entities;

namespace PruebaTecnica.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBuildRepository BuildRepository { get; }
        IDepartamentRepository DepartamentRepository { get; }
        IOwnerRepository OwnerRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();

    }
}

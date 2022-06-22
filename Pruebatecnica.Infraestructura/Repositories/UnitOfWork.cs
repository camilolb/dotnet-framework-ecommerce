using System.Threading.Tasks;
using Pruebatecnica.Infrastructura.Data;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;

namespace Pruebatecnica.Infraestructura.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _dbContext;

        private readonly IBuildRepository _buildRepository;
        private readonly IDepartamentRepository _departamentRepository;
        private readonly IOwnerRepository _ownerRepository;
         
        
        public UnitOfWork(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IBuildRepository BuildRepository => _buildRepository ?? new BuildRepository(_dbContext);
        public IDepartamentRepository DepartamentRepository => _departamentRepository ?? new DepartamentRepository(_dbContext);
        public IOwnerRepository OwnerRepository => _ownerRepository ?? new OwnerRepository(_dbContext);

        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

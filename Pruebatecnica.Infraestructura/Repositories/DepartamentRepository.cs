using Pruebatecnica.Infrastructura.Data;
using PruebaTecnica.Core.Interfaces;
using PruebaTecnica.Core.Entities;


namespace Pruebatecnica.Infraestructura.Repositories
{
    public class DepartamentRepository :  BaseRepository<Departament>, IDepartamentRepository
    {
        public DepartamentRepository(DatabaseContext context) : base(context) { }
    }
}

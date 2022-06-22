using System;
using Pruebatecnica.Infrastructura.Data;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;

namespace Pruebatecnica.Infraestructura.Repositories
{
    public class BuildRepository : BaseRepository<Build>, IBuildRepository
    {
        public BuildRepository(DatabaseContext context) : base(context) { }
    }
}

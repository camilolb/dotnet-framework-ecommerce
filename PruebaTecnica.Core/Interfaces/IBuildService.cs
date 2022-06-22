using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.QueryFilters;

namespace PruebaTecnica.Core.Interfaces
{
    public interface IBuildService
    {
        IEnumerable<Build> Gets();
        Task<Build> Get(int id);
        Task Insert(Build item);
        void Update(Build item);
        IEnumerable<Build> BuildAndDepartaments(int id);
        IEnumerable<Build> BuildFilter(BuildQueryFilter filterQuery);
    }
}




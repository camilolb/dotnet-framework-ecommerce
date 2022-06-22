using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaTecnica.Core.Entities;


namespace PruebaTecnica.Core.Interfaces
{
    public interface IOwnerService
    {
        IEnumerable<Owner> Gets();
        Task<Owner> Get(int id);
        Task Insert(Owner item);
        void Update(Owner item);
        IEnumerable<Owner> OwnerGetDepartaments(int id);
    }
}

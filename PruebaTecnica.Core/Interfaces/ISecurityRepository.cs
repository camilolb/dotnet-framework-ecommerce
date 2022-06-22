using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaTecnica.Core.Entities;

namespace PruebaTecnica.Core.Interfaces
{
    public interface ISecurityRepository
    {
        Task<Security> GetByEmail(string email);
        Task<Security> Get(int id);
        Task<Security> Get(string userName, string password);
        Task Insert(Security item);
        Task<bool> Update(Security item);
        Task<bool> Delete(int id);
    }
}

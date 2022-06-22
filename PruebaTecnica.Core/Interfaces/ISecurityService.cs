using System.Threading.Tasks;
using PruebaTecnica.Core.Entities;

namespace PruebaTecnica.Core.Interfaces
{
    public interface ISecurityService
    {
        Task<Security> Get(int id);
        Task<Security> Get(string userName, string passWord);
        Task Insert(Security item);
        Task<bool> Update(Security item);
        Task<bool> Delete(int id);
    }
}

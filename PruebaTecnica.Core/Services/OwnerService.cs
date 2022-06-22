using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;


namespace PruebaTecnica.Core.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OwnerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Owner> Get(int id)
        {
            return await _unitOfWork.OwnerRepository.GetById(id);
        }

        public IEnumerable<Owner> Gets()
        {
            return _unitOfWork.OwnerRepository.GetAll();
        }

        public IEnumerable<Owner> OwnerGetDepartaments(int id)
        {
            var includes = new string[] { "Departament"};

            var res = _unitOfWork.OwnerRepository.Find(x => x.Id == id, includes);
            return res;
        }

        public async Task Insert(Owner item)
        {
            await _unitOfWork.OwnerRepository.Add(item);
            _unitOfWork.SaveChanges();
        }

        public void Update(Owner item)
        {
            _unitOfWork.OwnerRepository.Update(item);
            _unitOfWork.SaveChanges();

        }

        public async Task Delete(int id)
        {
            await _unitOfWork.OwnerRepository.Delete(id);
            _unitOfWork.SaveChanges();

        }
    }
}

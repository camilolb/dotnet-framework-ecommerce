using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;
using PruebaTecnica.Core.QueryFilters;

namespace PruebaTecnica.Core.Services
{
    public class DepartamentService : IDepartamentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartamentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Departament> Get(int id)
        {
            var res = await _unitOfWork.DepartamentRepository.GetById(id);
            return res;
        }

        public IEnumerable<Departament> Gets()
        {
            return _unitOfWork.DepartamentRepository.GetAll();
        }

        public IEnumerable<Departament> GetAll()
        {
            var includes = new string[] { "Ower" };
            return  _unitOfWork.DepartamentRepository.GetAll(includes);
        }

        public IEnumerable<Departament> DepartamentAndOwner(int id)
        {
            var includes = new string[] { "Ower", "Build" };

            var res = _unitOfWork.DepartamentRepository.Find(x => x.Id == id, includes);
            return res;
        }

        public IEnumerable<Departament> DepartamentFilter(DepartamentQueryFilter departamentQueryFilter)
        {
            var departament = _unitOfWork.DepartamentRepository.GetAll();
            var response = this.FilterListDepartament(departament, departamentQueryFilter);
            return response;
        }

        public async Task Insert(Departament item)
        {
            var validate = GetExistNumber(item);

            if (validate)
            {
                throw new System.Exception("Departament exist");
            }

            await _unitOfWork.DepartamentRepository.Add(item);
            _unitOfWork.SaveChanges();
        }

        public void Update(Departament item)
        {
            _unitOfWork.DepartamentRepository.Update(item);
            _unitOfWork.SaveChanges();
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.DepartamentRepository.Delete(id);
            _unitOfWork.SaveChanges();
        }


        private bool GetExistNumber(Departament item)
        {
            var validate = _unitOfWork.DepartamentRepository.Find(x => x.Number == item.Number).Any();
            return validate;
        }

        private IEnumerable<Departament> FilterListDepartament(IEnumerable<Departament> res, DepartamentQueryFilter departamentQueryFilter)
        {
            IEnumerable<Departament> filter = new List<Departament>();

            if (departamentQueryFilter.Number != null)
            {
                filter = res.Where(x => x.Number == departamentQueryFilter.Number);
            }

            if (departamentQueryFilter.Price != null)
            {
                filter = res.Where(x => x.Price == departamentQueryFilter.Price);
            }

            return filter;
        }
    }
}

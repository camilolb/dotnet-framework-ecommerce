using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;
using PruebaTecnica.Core.QueryFilters;

namespace PruebaTecnica.Core.Services
{
    public class BuildService : IBuildService
    {

        private readonly IUnitOfWork _unitOfWork;


        public BuildService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Build> Get(int id)
        {
            return await _unitOfWork.BuildRepository.GetById(id);
        }

        public IEnumerable<Build> BuildAndDepartaments(int id)
        {
            var includes = new string[] { "Departaments" };

            var res = _unitOfWork.BuildRepository.Find(x => x.Id == id, includes);
            return res;
        }


        public IEnumerable<Build> Gets()
        {
            var res = _unitOfWork.BuildRepository.GetAll();
            return res;
        }

        public IEnumerable<Build> BuildFilter(BuildQueryFilter filterQuery)
        {
            var res = _unitOfWork.BuildRepository.GetAll();
            this.FilterListBuild(res, filterQuery);

            return res;
        }

        public async Task Insert(Build item)
        {
            await _unitOfWork.BuildRepository.Add(item);
            _unitOfWork.SaveChanges();
        }

        public void Update(Build item)
        {
            _unitOfWork.BuildRepository.Update(item);
            _unitOfWork.SaveChanges();

        }

        public async Task Delete(int id)
        {
            await _unitOfWork.BuildRepository.Delete(id);
            _unitOfWork.SaveChanges();

        }


        private void FilterListBuild(IEnumerable<Build> res, BuildQueryFilter filterQuery)
        {
            if (filterQuery.Name != null)
            {
                res.Where(x => x.Name == filterQuery.Name);
            }

            if (filterQuery.Adress != null)
            {
                res.Where(x => x.Address == filterQuery.Adress);
            }

            if (filterQuery.Tower != null)
            {
                res.Where(x => x.Tower == filterQuery.Tower);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;
using PruebaTecnica.Core.Services;
using Xunit;


namespace UnitTest
{
    public class DepartamentServiceTest
    {


        private readonly DepartamentService _departamentService;
        private readonly Mock<IUnitOfWork> _unitOfWork = new Mock<IUnitOfWork>();

        public DepartamentServiceTest()
        {
            _departamentService = new DepartamentService(_unitOfWork.Object);
        }


        [Fact]

        public void Get_Build_By_Id()
        {
            //Arange
            var id = 1;
            //Act
            var res = _departamentService.Get(id);

            //Asert
            Assert.Equal(id, res.Id);
        }



        [Fact]
        public void Get_Departament_All()
        {
            var objectsList = new List<Departament>() {
                new  Departament{
                Number = "1805",
                OwerId = 1,
                BuildId = 1
                },
                 new  Departament{
                Number = "1907",
                OwerId = 1,
                BuildId = 1
                }
            };

            _unitOfWork.Setup<IEnumerable<Departament>>(
                rep => rep.DepartamentRepository.GetAll()
            ).Returns((objectsList));

            var res = _departamentService.Gets();

            Assert.NotEmpty(res);
        }


        [Fact]
        public async Task Post_Departament()
        {

            try
            {
                Departament departament = new Departament
                {
                    Number = "1907",
                    OwerId = 1,
                    BuildId = 1
                };

                _unitOfWork.Setup(
                   rep => rep.DepartamentRepository.Add(departament)
               );

                await _departamentService.Insert(departament);
                Assert.NotNull(departament);
            }
            catch (Exception ex)
            {
                Assert.Throws<Exception>(() => ex.Message);
            }

        }

    }
}

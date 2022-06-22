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
    public class OwnerServiceTest
    {
        private readonly OwnerService _ownerService;
        private readonly Mock<IUnitOfWork> _unitOfWork = new Mock<IUnitOfWork>();

        public OwnerServiceTest()
        {
            _ownerService = new OwnerService(_unitOfWork.Object);
        }


        [Fact]
        public void Get_Owner_By_Id()
        {
            //Arange
            var id = 1;
            //Act
            var res = _ownerService.Get(id);
            //Asert
            Assert.Equal(id, res.Id);
        }


        [Fact]
        public void Get_Departament_All()
        {
            var objectsList = new List<Owner>() {
                new  Owner{
                FullName = "Cristian López",
                Adress = "calle 78 sur 44",
                Phone = "300357874"
                },
                new  Owner{
                FullName = "Solecito agudelo",
                Adress = "calle 78 sur 44",
                Phone = "78997474"
                }
            };

            _unitOfWork.Setup<IEnumerable<Owner>>(
                rep => rep.OwnerRepository.GetAll()
            ).Returns((objectsList));

            var res = _ownerService.Gets();

            Assert.NotEmpty(res);
        }


        [Fact]
        public async Task Post_Departament()
        {

            try
            {
                Owner owner = new Owner
                {
                    FullName = "Cristian López",
                    Adress = "calle 78 sur 44",
                    Phone = "300357874"
                };

                _unitOfWork.Setup(
                   rep => rep.OwnerRepository.Add(owner)
               );

                await _ownerService.Insert(owner);
                Assert.NotNull(owner);
            }
            catch (Exception ex)
            {
                Assert.Throws<Exception>(() => ex.Message);
            }

        }

    }
}

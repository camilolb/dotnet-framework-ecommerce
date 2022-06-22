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
    public class BuildServiceTest
    {

        private readonly BuildService _buildService;
        private readonly Mock<IUnitOfWork> _unitOfWork = new Mock<IUnitOfWork>();
         
        public BuildServiceTest()
        {
            _buildService = new BuildService(_unitOfWork.Object);
        }

        [Fact]
        public void Get_Build_By_Id()
        {
            //Arange
            var id = 1;
            //Act
            var res =  _buildService.Get(id);

            //Asert
            Assert.Equal(id, res.Id);
        }


        [Fact]
        public void Get_Build_All()
        {
            var objectsList = new List<Build>() {
                new Build {
                Name = "Boque Verde",
                Address = "calle 83 a sur 45-77",
                Tower = "2"
                },
                 new Build {
                Name = "Carolinigio",
                Address = "calle 87 sur 78-33",
                Tower = "1"
                }
            };

            _unitOfWork.Setup<IEnumerable<Build>>(
                rep => rep.BuildRepository.GetAll()
            ).Returns((objectsList));

            var res = _buildService.Gets();
            Assert.NotEmpty(res);
        }


        [Fact]
        public async Task Post_Build()
        {

            try
            {
                Build build = new Build
                {
                    Name = "Loreto",
                    Address = "calle 78 norte 78-66",
                    Tower = "1"
                };

                _unitOfWork.Setup(
                   rep => rep.BuildRepository.Add(build)
               );

                await _buildService.Insert(build);
                Assert.NotNull(build);
            }
            catch (Exception ex)
            {
                Assert.Throws<Exception>(() => ex.Message);
            }

        }

    }
}

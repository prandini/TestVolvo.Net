using App.Volvo.Business.Interfaces;
using App.Volvo.Business.Models;
using App.Volvo.Business.Services;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace App.Volvo.Business.Test
{
    public class CaminhaoServiceTest
    {
        private readonly CaminhaoService _caminhaoService;

        private readonly Mock<ICaminhaoRepository> _caminhaoRepositoryMoq = new Mock<ICaminhaoRepository>();
        private readonly Mock<INotifier> _notifierMoq = new Mock<INotifier>();

        public CaminhaoServiceTest()
        {
            _caminhaoService = new CaminhaoService(_caminhaoRepositoryMoq.Object, _notifierMoq.Object);
        }

        [Fact]
        public async Task Insert_ShouldNotInsert_WhenIsNotexecutedValidation()
        {
            //Arrange
            var caminhao = new Mock<Caminhao>();

            //Act
            await _caminhaoService.Insert(caminhao.Object);

            //Assert
            _caminhaoRepositoryMoq.Verify(v => v.Insert(caminhao.Object), Times.Never);
        }

        [Fact]
        public async Task Insert_ShouldInsert_WhenIsNotexecutedValidationIsFalse()
        {
            //Arrange
            var year = (short)DateTime.Now.Year;
            var caminhao = new Caminhao
            {
                AnoFabricacao = year,
                AnoModelo = year,
                Chassi = "KAJSHDGKJASDGHKJA"
            };

            //Act
            await _caminhaoService.Insert(caminhao);

            //Assert
            _caminhaoRepositoryMoq.Verify(v => v.Insert(caminhao), Times.Once);
        }

        [Fact]
        public async Task Update_ShouldNotUpdate_WhenIsNotexecutedValidation()
        {
            //Arrange
            var caminhao = new Mock<Caminhao>();

            //Act
            await _caminhaoService.Update(caminhao.Object);

            //Assert
            _caminhaoRepositoryMoq.Verify(v => v.Update(caminhao.Object), Times.Never);
        }


        [Fact]
        public async Task Update_ShouldInsert_WhenIsNotexecutedValidationIsFalse()
        {
            //Arrange
            var year = (short)DateTime.Now.Year;
            var caminhao = new Caminhao
            {
                AnoFabricacao = year,
                AnoModelo = year,
                Chassi = "KAJSHDGKJASDGHKJA"
            };

            //Act
            await _caminhaoService.Update(caminhao);

            //Assert
            _caminhaoRepositoryMoq.Verify(v => v.Update(caminhao), Times.Once);
        }


        [Fact]
        public async Task Delete_ShouldDelete()
        {
            //Arrange
            var id = Guid.NewGuid();

            //Act
            await _caminhaoService.Delete(id);

            //Assert
            _caminhaoRepositoryMoq.Verify(v => v.Delete(id), Times.Once);
        }
    }
}

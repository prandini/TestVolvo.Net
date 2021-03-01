using App.Volvo.Business.Interfaces;
using App.Volvo.Business.Models;
using App.Volvo.Business.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace App.Volvo.Business.Test
{
    public class ModeloServiceTest
    {
        private readonly ModeloService _modeloService;

        private readonly Mock<IModeloRepository> _modeloRepository = new Mock<IModeloRepository>();
        private readonly Mock<INotifier> _notifierMoq = new Mock<INotifier>();


        public ModeloServiceTest()
        {
            _modeloService = new ModeloService(_modeloRepository.Object, _notifierMoq.Object);
        }

        [Fact]
        public async Task Insert_ShouldNotInsert_WhenIsNotexecutedValidation()
        {
            //Arrange
            var modelo = new Mock<Modelo>();

            //Act
            await _modeloService.Insert(modelo.Object);

            //Assert
            _modeloRepository.Verify(v => v.Insert(modelo.Object), Times.Never);
        }


        [Fact]
        public async Task Insert_ShouldInsert_WhenIsNotexecutedValidationIsFalse()
        {
            //Arrange
            var modelo = new Modelo()
            {
                Nome = "FH",
                IsPermitidoCadastro = false
            };

            //Act
            await _modeloService.Insert(modelo);

            //Assert
            _modeloRepository.Verify(v => v.Insert(modelo), Times.Once);
        }

        [Fact]
        public async Task Update_ShouldNotUpdate_WhenIsNotexecutedValidation()
        {
            //Arrange
            var modelo = new Mock<Modelo>();

            //Act
            await _modeloService.Update(modelo.Object);

            //Assert
            _modeloRepository.Verify(v => v.Update(modelo.Object), Times.Never);
        }


        [Fact]
        public async Task Update_ShouldUpdate_WhenIsNotexecutedValidationIsFalse()
        {
            //Arrange
            var modelo = new Modelo()
            {
                Nome = "FH",
                IsPermitidoCadastro = false
            };

            //Act
            await _modeloService.Update(modelo);

            //Assert
            _modeloRepository.Verify(v => v.Update(modelo), Times.Once);
        }
    }
}

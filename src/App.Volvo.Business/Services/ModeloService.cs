using App.Volvo.Business.Interfaces;
using App.Volvo.Business.Models;
using App.Volvo.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Volvo.Business.Services
{
    public class ModeloService : BaseService, IModeloService
    {
        private readonly IModeloRepository _modeloRepository;

        public ModeloService(IModeloRepository modeloRepository, INotifier notifier) : base(notifier)
        {
            _modeloRepository = modeloRepository;
        }

        public async Task Delete(Guid Id)
        {
            await _modeloRepository.Delete(Id);
        }

        public async Task Insert(Modelo modelo)
        {
            var IsNotexecutedValidation = ExecuteValidation(new ModeloValidation(), modelo) == false;
            if (IsNotexecutedValidation)
            {
                return;
            }

            await _modeloRepository.Insert(modelo);
        }

        public async Task Update(Modelo modelo)
        {
            var IsNotexecutedValidation = ExecuteValidation(new ModeloValidation(), modelo) == false;
            if (IsNotexecutedValidation)
            {
                return;
            }

            await _modeloRepository.Update(modelo);
        }

        public void Dispose()
        {
            _modeloRepository.Dispose();
        }

        public async Task<IEnumerable<Modelo>> GetModelosPermitidoCadastro()
        {
            return await _modeloRepository.Search(s => s.IsPermitidoCadastro);
        }
    }
}

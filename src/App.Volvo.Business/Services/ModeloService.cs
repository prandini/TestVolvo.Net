using App.Volvo.Business.Interfaces;
using App.Volvo.Business.Models;
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

        public Task Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Modelo caminhao)
        {
            throw new NotImplementedException();
        }

        public Task Update(Modelo caminhao)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _modeloRepository.Dispose();
        }
    }
}

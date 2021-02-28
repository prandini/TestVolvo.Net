using App.Volvo.Business.Interfaces;
using App.Volvo.Business.Models;
using App.Volvo.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Volvo.Business.Services
{
    public class CaminhaoService : BaseService, ICaminhaoService
    {
        private readonly ICaminhaoRepository _caminhaoRepository;

        public CaminhaoService(ICaminhaoRepository caminhaoRepository, INotifier notifier) : base(notifier)
        {
            _caminhaoRepository = caminhaoRepository;
        }

        public async Task Insert(Caminhao caminhao)
        {
            var IsNotexecutedValidation = ExecuteValidation(new CaminhaoValidation(), caminhao) == false;
            if (IsNotexecutedValidation)
            {
                return;
            }

            await _caminhaoRepository.Insert(caminhao);
        }

        public async Task Update(Caminhao caminhao)
        {
            var IsNotexecutedValidation = ExecuteValidation(new CaminhaoValidation(), caminhao) == false;
            if (IsNotexecutedValidation)
            {
                return;
            }

            await _caminhaoRepository.Update(caminhao);
        }

        public async Task Delete(Guid Id)
        {
            await _caminhaoRepository.Delete(Id);
        }

        public void Dispose()
        {
            _caminhaoRepository.Dispose();
        }
    }
}

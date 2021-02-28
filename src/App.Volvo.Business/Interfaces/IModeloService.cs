using App.Volvo.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Volvo.Business.Interfaces
{
    public interface IModeloService : IDisposable
    {
        Task Insert(Modelo modelo);
        Task Update(Modelo modelo);
        Task Delete(Guid Id);

        Task<IEnumerable<Modelo>> GetModelosPermitidoCadastro();
    }
}
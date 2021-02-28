using App.Volvo.Business.Models;
using System;
using System.Threading.Tasks;

namespace App.Volvo.Business.Interfaces
{
    public interface IModeloService : IDisposable
    {
        Task Insert(Modelo caminhao);
        Task Update(Modelo caminhao);
        Task Delete(Guid Id);
    }
}
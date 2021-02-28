using App.Volvo.Business.Models;
using System;
using System.Threading.Tasks;

namespace App.Volvo.Business.Interfaces
{
    public interface ICaminhaoService : IDisposable
    {
        Task Insert(Caminhao caminhao);
        Task Update(Caminhao caminhao);
        Task Delete(Guid Id);
    }

}
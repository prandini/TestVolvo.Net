using App.Volvo.Business.Models;
using System;
using System.Threading.Tasks;

namespace App.Volvo.Business.Interfaces
{
    public interface ICaminhaoRepository : IRepository<Caminhao>
    {
        Task<Caminhao> GetCaminhaoModelo(Guid Id);
    }
}

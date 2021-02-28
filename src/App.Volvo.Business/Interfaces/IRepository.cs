using App.Volvo.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Volvo.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Insert(TEntity entity);
        Task<TEntity> GetById(Guid id);
        Task<List<TEntity>> GetAll();
        Task Update(TEntity entity);
        Task Delete(Guid id);

        Task<int> SaveChanges();

    }
}

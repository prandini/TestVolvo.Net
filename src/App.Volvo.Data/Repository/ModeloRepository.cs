using App.Volvo.Business.Interfaces;
using App.Volvo.Business.Models;
using App.Volvo.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Volvo.Data.Repository
{
    public class ModeloRepository : Repository<Modelo>, IModeloRepository
    {
        public ModeloRepository(AppVolvoDbContext context) : base(context)
        {
        }
    }
}

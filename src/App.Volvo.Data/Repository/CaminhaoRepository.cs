using App.Volvo.Business.Interfaces;
using App.Volvo.Business.Models;
using App.Volvo.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace App.Volvo.Data.Repository
{
    public class CaminhaoRepository : Repository<Caminhao>, ICaminhaoRepository
    {
        public CaminhaoRepository(AppVolvoDbContext context) : base(context)
        {
        }

        public async Task<Caminhao> GetCaminhaoModelo(Guid Id)
        {
            return await dbContext.Caminhoes
                .AsNoTracking()
                .Include(p => p.Modelo)
                .FirstOrDefaultAsync(c => c.Id == Id);
        }
    }
}

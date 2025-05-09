using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Data;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Implementations
{
    public class CargaRepository : ICargaRepository
    {
        private readonly ERPContext _context;

        public CargaRepository(ERPContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Carga>> GetAllAsync() => await _context.Cargas.ToListAsync();
        public async Task<Carga> GetByIdAsync(int id) => await _context.Cargas.FindAsync(id);
        public async Task<Carga> AddAsync(Carga item)
        {
            _context.Cargas.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }
        public async Task UpdateAsync(Carga item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var item = await _context.Cargas.FindAsync(id);
            if (item != null)
            {
                _context.Cargas.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
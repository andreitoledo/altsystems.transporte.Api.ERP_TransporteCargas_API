using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Data;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Implementations
{
    public class TransportadoraRepository : ITransportadoraRepository
    {
        private readonly ERPContext _context;

        public TransportadoraRepository(ERPContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transportadora>> GetAllAsync() => await _context.Transportadoras.ToListAsync();
        public async Task<Transportadora> GetByIdAsync(int id) => await _context.Transportadoras.FindAsync(id);
        public async Task<Transportadora> AddAsync(Transportadora item)
        {
            _context.Transportadoras.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }
        public async Task UpdateAsync(Transportadora item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var item = await _context.Transportadoras.FindAsync(id);
            if (item != null)
            {
                _context.Transportadoras.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
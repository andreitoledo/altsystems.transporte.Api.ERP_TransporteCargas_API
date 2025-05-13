using altsystems.transporte.Api.ERP_TransporteCargas_API.Data;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Implementations
{
    public class ViagemRepository : IViagemRepository
    {
        private readonly ERPContext _context;

        public ViagemRepository(ERPContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Viagem>> GetAllAsync()
        {
            return await _context.Viagens
                .Include(v => v.Itinerarios)
                .ToListAsync();
        }


        public async Task<Viagem?> GetByIdAsync(int id)
        {
            return await _context.Viagens.Include(v => v.Itinerarios)
                                         .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task AddAsync(Viagem viagem)
        {
            _context.Viagens.Add(viagem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Viagem viagem)
        {
            _context.Viagens.Update(viagem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Viagem viagem)
        {
            _context.Viagens.Remove(viagem);
            await _context.SaveChangesAsync();
        }
    }
}

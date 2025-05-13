using altsystems.transporte.Api.ERP_TransporteCargas_API.Data;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Implementations
{
    public class ItinerarioRepository : IItinerarioRepository
    {
        private readonly ERPContext _context;

        public ItinerarioRepository(ERPContext context)
        {
            _context = context;
        }

        public async Task<List<Itinerario>> GetAllAsync()
        {
            return await _context.Itinerarios.ToListAsync();
        }

        public async Task<Itinerario?> GetByIdAsync(int id)
        {
            return await _context.Itinerarios.FindAsync(id);
        }

        public async Task AddAsync(Itinerario itinerario)
        {
            _context.Itinerarios.Add(itinerario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Itinerario itinerario)
        {
            _context.Itinerarios.Update(itinerario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Itinerario itinerario)
        {
            _context.Itinerarios.Remove(itinerario);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Itinerario>> GetByViagemIdAsync(int viagemId)
        {
            return await _context.Itinerarios
                                 .Where(i => i.ViagemId == viagemId)
                                 .ToListAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var itinerario = await _context.Itinerarios.FindAsync(id);
            if (itinerario != null)
            {
                _context.Itinerarios.Remove(itinerario);
                await _context.SaveChangesAsync();
            }
        }


    }
}

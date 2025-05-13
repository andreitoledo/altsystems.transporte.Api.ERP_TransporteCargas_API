using altsystems.transporte.Api.ERP_TransporteCargas_API.Data;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Implementations
{
    public class MotoristaRepository : IMotoristaRepository
    {
        private readonly ERPContext _context;
        public MotoristaRepository(ERPContext context) => _context = context;

        public async Task<List<Motorista>> GetAllAsync() => await _context.Motoristas.ToListAsync();
        public async Task<Motorista> GetByIdAsync(int id) => await _context.Motoristas.FindAsync(id);
        public async Task AddAsync(Motorista entity) { _context.Motoristas.Add(entity); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(Motorista entity) { _context.Motoristas.Update(entity); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(Motorista entity) { _context.Motoristas.Remove(entity); await _context.SaveChangesAsync(); }
    }
}
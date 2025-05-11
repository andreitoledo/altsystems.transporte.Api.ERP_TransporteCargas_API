using altsystems.transporte.Api.ERP_TransporteCargas_API.Data;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Implementations
{
    public class InscricaoEstadualRepository : IInscricaoEstadualRepository
    {
        private readonly ERPContext _context;

        public InscricaoEstadualRepository(ERPContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InscricaoEstadual>> GetByClienteIdAsync(int clienteId)
        {
            return await _context.InscricoesEstaduais.Where(i => i.ClienteId == clienteId).ToListAsync();
        }

        public async Task<InscricaoEstadual> GetByIdAsync(int id)
        {
            return await _context.InscricoesEstaduais.FindAsync(id);
        }

        public async Task AddAsync(InscricaoEstadual inscricaoEstadual)
        {
            await _context.InscricoesEstaduais.AddAsync(inscricaoEstadual);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(InscricaoEstadual inscricaoEstadual)
        {
            _context.InscricoesEstaduais.Update(inscricaoEstadual);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(InscricaoEstadual inscricaoEstadual)
        {
            _context.InscricoesEstaduais.Remove(inscricaoEstadual);
            await _context.SaveChangesAsync();
        }
    }
}

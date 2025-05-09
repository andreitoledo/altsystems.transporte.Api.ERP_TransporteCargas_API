using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Data;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Implementations
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly ERPContext _context;

        public VeiculoRepository(ERPContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Veiculo>> GetAllAsync() => await _context.Veiculos.ToListAsync();
        public async Task<Veiculo> GetByIdAsync(int id) => await _context.Veiculos.FindAsync(id);
        public async Task<Veiculo> AddAsync(Veiculo item)
        {
            _context.Veiculos.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }
        public async Task UpdateAsync(Veiculo item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var item = await _context.Veiculos.FindAsync(id);
            if (item != null)
            {
                _context.Veiculos.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
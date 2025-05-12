using altsystems.transporte.Api.ERP_TransporteCargas_API.Data;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Implementations
{
    public class ClienteCnpjRepository : IClienteCnpjRepository
    {
        private readonly ERPContext _context;

        public ClienteCnpjRepository(ERPContext context)
        {
            _context = context;
        }

        public async Task<ClienteCnpj> GetByClienteIdAsync(int clienteId)
        {
            return await _context.ClienteCnpjs.FirstOrDefaultAsync(c => c.ClienteId == clienteId);
        }

        public async Task AddAsync(ClienteCnpj clienteCnpj)
        {
            await _context.ClienteCnpjs.AddAsync(clienteCnpj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ClienteCnpj clienteCnpj)
        {
            _context.ClienteCnpjs.Update(clienteCnpj);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ClienteCnpj clienteCnpj)
        {
            _context.ClienteCnpjs.Remove(clienteCnpj);
            await _context.SaveChangesAsync();
        }

        public async Task<ClienteCnpj> GetByIdAsync(int id)
        {
            return await _context.ClienteCnpjs.FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}

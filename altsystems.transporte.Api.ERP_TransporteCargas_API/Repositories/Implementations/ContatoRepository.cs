using altsystems.transporte.Api.ERP_TransporteCargas_API.Data;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Implementations
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly ERPContext _context;

        public ContatoRepository(ERPContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contato>> ObterPorClienteAsync(int clienteId)
        {
            return await _context.Contatos
                .Where(c => c.ClienteId == clienteId)
                .ToListAsync();
        }

        public async Task<Contato> ObterPorIdAsync(int id)
        {
            return await _context.Contatos.FindAsync(id);
        }

        public async Task<Contato> AdicionarAsync(Contato contato)
        {
            _context.Contatos.Add(contato);
            await _context.SaveChangesAsync();
            return contato;
        }

        public async Task AtualizarAsync(int id, Contato contato)
        {
            var existente = await ObterPorIdAsync(id);
            if (existente == null) throw new Exception("Contato não encontrado");

            existente.Nome = contato.Nome;
            existente.Email = contato.Email;
            existente.Telefone = contato.Telefone;

            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var contato = await ObterPorIdAsync(id);
            if (contato != null)
            {
                _context.Contatos.Remove(contato);
                await _context.SaveChangesAsync();
            }
        }
    }
}

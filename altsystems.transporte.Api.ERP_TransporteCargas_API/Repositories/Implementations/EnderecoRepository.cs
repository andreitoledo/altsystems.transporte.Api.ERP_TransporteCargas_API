using altsystems.transporte.Api.ERP_TransporteCargas_API.Data;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Implementations
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly ERPContext _context;

        public EnderecoRepository(ERPContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Endereco>> ObterPorClienteAsync(int clienteId)
        {
            return await _context.Enderecos
                .Where(e => e.ClienteId == clienteId)
                .ToListAsync();
        }

        public async Task<Endereco> ObterPorIdAsync(int id)
        {
            return await _context.Enderecos.FindAsync(id);
        }

        public async Task<Endereco> AdicionarAsync(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            await _context.SaveChangesAsync();
            return endereco;
        }

        public async Task AtualizarAsync(int id, Endereco endereco)
        {
            var existente = await ObterPorIdAsync(id);
            if (existente == null) throw new Exception("Endereço não encontrado");

            existente.Logradouro = endereco.Logradouro;
            existente.Cidade = endereco.Cidade;
            existente.Estado = endereco.Estado;

            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var endereco = await ObterPorIdAsync(id);
            if (endereco != null)
            {
                _context.Enderecos.Remove(endereco);
                await _context.SaveChangesAsync();
            }
        }
    }
}

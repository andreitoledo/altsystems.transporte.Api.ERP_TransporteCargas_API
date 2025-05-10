using altsystems.transporte.Api.ERP_TransporteCargas_API.Data;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Implementations
{
    public class DadosGeraisRepository : IDadosGeraisRepository
    {
        private readonly ERPContext _context;

        public DadosGeraisRepository(ERPContext context)
        {
            _context = context;
        }

        public async Task<DadosGerais> ObterPorClienteIdAsync(int clienteId)
        {
            return await _context.DadosGerais.FirstOrDefaultAsync(d => d.ClienteId == clienteId);
        }

        public async Task<DadosGerais> AdicionarOuAtualizarAsync(int clienteId, DadosGerais dados)
        {
            var existente = await ObterPorClienteIdAsync(clienteId);
            if (existente == null)
            {
                dados.ClienteId = clienteId;
                _context.DadosGerais.Add(dados);
            }
            else
            {
                existente.Cnpj = dados.Cnpj;
                existente.InscricaoEstadual = dados.InscricaoEstadual;
                existente.DataCadastro = dados.DataCadastro;
            }

            await _context.SaveChangesAsync();
            return dados;
        }

        public async Task<DadosGerais> ObterPorIdAsync(int id)
        {
            return await _context.DadosGerais.FindAsync(id);
        }

        public async Task AtualizarAsync(DadosGerais dados)
        {
            _context.DadosGerais.Update(dados);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(DadosGerais dados)
        {
            _context.DadosGerais.Remove(dados);
            await _context.SaveChangesAsync();
        }



    }

}

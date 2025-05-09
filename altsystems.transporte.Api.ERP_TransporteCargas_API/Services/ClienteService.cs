using System.Collections.Generic;
using System.Threading.Tasks;
using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _repo;

        public ClienteService(IClienteRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Cliente>> ListarClientesAsync() => await _repo.GetAllAsync();
        public async Task<Cliente> ObterClienteAsync(int id) => await _repo.GetByIdAsync(id);
        public async Task<Cliente> CriarClienteAsync(Cliente cliente) => await _repo.AddAsync(cliente);
        public async Task AtualizarClienteAsync(Cliente cliente) => await _repo.UpdateAsync(cliente);
        public async Task DeletarClienteAsync(int id) => await _repo.DeleteAsync(id);
    }
}
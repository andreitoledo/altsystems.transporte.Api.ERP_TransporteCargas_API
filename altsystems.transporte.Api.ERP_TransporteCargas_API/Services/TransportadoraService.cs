using System.Collections.Generic;
using System.Threading.Tasks;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Services
{
    public class TransportadoraService
    {
        private readonly ITransportadoraRepository _repo;

        public TransportadoraService(ITransportadoraRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Transportadora>> ListarAsync() => await _repo.GetAllAsync();
        public async Task<Transportadora> ObterAsync(int id) => await _repo.GetByIdAsync(id);
        public async Task<Transportadora> CriarAsync(Transportadora item) => await _repo.AddAsync(item);
        public async Task AtualizarAsync(Transportadora item) => await _repo.UpdateAsync(item);
        public async Task DeletarAsync(int id) => await _repo.DeleteAsync(id);
    }
}
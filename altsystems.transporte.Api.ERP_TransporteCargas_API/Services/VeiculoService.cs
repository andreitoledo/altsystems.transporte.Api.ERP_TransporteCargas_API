using System.Collections.Generic;
using System.Threading.Tasks;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Services
{
    public class VeiculoService
    {
        private readonly IVeiculoRepository _repo;

        public VeiculoService(IVeiculoRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Veiculo>> ListarAsync() => await _repo.GetAllAsync();
        public async Task<Veiculo> ObterAsync(int id) => await _repo.GetByIdAsync(id);
        public async Task<Veiculo> CriarAsync(Veiculo item) => await _repo.AddAsync(item);
        public async Task AtualizarAsync(Veiculo item) => await _repo.UpdateAsync(item);
        public async Task DeletarAsync(int id) => await _repo.DeleteAsync(id);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Services
{
    public class CargaService
    {
        private readonly ICargaRepository _repo;

        public CargaService(ICargaRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Carga>> ListarAsync() => await _repo.GetAllAsync();
        public async Task<Carga> ObterAsync(int id) => await _repo.GetByIdAsync(id);
        public async Task<Carga> CriarAsync(Carga item) => await _repo.AddAsync(item);
        public async Task AtualizarAsync(Carga item) => await _repo.UpdateAsync(item);
        public async Task DeletarAsync(int id) => await _repo.DeleteAsync(id);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces;
using AutoMapper;
using ERPTransporte.Services.Interfaces;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _repo;
        private readonly IMapper _mapper;

        public VeiculoService(IVeiculoRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VeiculoDTO>> ObterTodosAsync() =>
            _mapper.Map<IEnumerable<VeiculoDTO>>(await _repo.GetAllAsync());

        public async Task<VeiculoDTO> ObterPorIdAsync(int id) =>
            _mapper.Map<VeiculoDTO>(await _repo.GetByIdAsync(id));

        public async Task<VeiculoDTO> CriarAsync(VeiculoDTO dto)
        {
            var entidade = _mapper.Map<Veiculo>(dto);
            await _repo.AddAsync(entidade);
            return _mapper.Map<VeiculoDTO>(entidade);
        }

        public async Task AtualizarAsync(int id, VeiculoDTO dto)
        {
            var entidade = await _repo.GetByIdAsync(id);
            if (entidade == null) throw new KeyNotFoundException();
            _mapper.Map(dto, entidade);
            await _repo.UpdateAsync(entidade);
        }

        public async Task RemoverAsync(int id)
        {
            var entidade = await _repo.GetByIdAsync(id);
            if (entidade == null) throw new KeyNotFoundException();
            await _repo.DeleteAsync(entidade);
        }
    }
}
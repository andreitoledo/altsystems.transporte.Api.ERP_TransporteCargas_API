using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Services.Interfaces;
using AutoMapper;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Services
{
    public class MotoristaService : IMotoristaService
    {
        private readonly IMotoristaRepository _repo;
        private readonly IMapper _mapper;

        public MotoristaService(IMotoristaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<MotoristaDTO>> ObterTodosAsync()
        {
            var lista = await _repo.GetAllAsync();
            return _mapper.Map<List<MotoristaDTO>>(lista);
        }

        public async Task<MotoristaDTO> ObterPorIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return _mapper.Map<MotoristaDTO>(entity);
        }

        public async Task CriarAsync(MotoristaDTO dto)
        {
            var entity = _mapper.Map<Motorista>(dto);
            await _repo.AddAsync(entity);
        }

        public async Task AtualizarAsync(int id, MotoristaDTO dto)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) throw new Exception("Registro não encontrado.");

            _mapper.Map(dto, entity);
            await _repo.UpdateAsync(entity);
        }

        public async Task RemoverAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity != null)
                await _repo.DeleteAsync(entity);
        }
    }
}
using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Services.Interfaces;
using AutoMapper;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Services
{
    public class ViagemService : IViagemService
    {
        private readonly IViagemRepository _repository;
        private readonly IMapper _mapper;

        public ViagemService(IViagemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ViagemDTO>> ObterTodosAsync()
        {
            var viagens = await _repository.GetAllAsync();
            return _mapper.Map<List<ViagemDTO>>(viagens);
        }

        public async Task<ViagemDTO?> ObterPorIdAsync(int id)
        {
            var viagem = await _repository.GetByIdAsync(id);
            return _mapper.Map<ViagemDTO?>(viagem);
        }

        public async Task CriarAsync(ViagemDTO dto)
        {
            var viagem = _mapper.Map<Viagem>(dto);
            await _repository.AddAsync(viagem);
        }

        public async Task AtualizarAsync(ViagemDTO dto)
        {
            var viagem = _mapper.Map<Viagem>(dto);
            await _repository.UpdateAsync(viagem);
        }

        public async Task RemoverAsync(int id)
        {
            var viagem = await _repository.GetByIdAsync(id);
            if (viagem is not null)
                await _repository.DeleteAsync(viagem);
        }
    }
}

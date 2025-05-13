using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Implementations;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Services.Interfaces;
using AutoMapper;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Services
{
    public class ItinerarioService : IItinerarioService
    {
        private readonly IItinerarioRepository _repository;
        private readonly IMapper _mapper;

        public ItinerarioService(IItinerarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ItinerarioDTO>> ObterTodosAsync()
        {
            var lista = await _repository.GetAllAsync();
            return _mapper.Map<List<ItinerarioDTO>>(lista);
        }

        public async Task<ItinerarioDTO?> ObterPorIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<ItinerarioDTO?>(entity);
        }

        public async Task CriarAsync(ItinerarioDTO dto)
        {
            var entity = _mapper.Map<Itinerario>(dto);
            await _repository.AddAsync(entity);
        }

        public async Task AtualizarAsync(ItinerarioDTO dto)
        {
            var entity = _mapper.Map<Itinerario>(dto);
            await _repository.UpdateAsync(entity);
        }

        public async Task RemoverAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is not null)
                await _repository.DeleteAsync(entity);
        }

        public async Task<List<ItinerarioDTO>> ObterPorViagemIdAsync(int viagemId)
        {
            var itinerarios = await _repository.GetByViagemIdAsync(viagemId);
            return _mapper.Map<List<ItinerarioDTO>>(itinerarios);
        }

        public async Task ExcluirAsync(int id)
        {
            await _repository.RemoverAsync(id);
        }


    }
}
